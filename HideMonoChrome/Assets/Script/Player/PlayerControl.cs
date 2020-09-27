using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private State _state;               // 現在の状態
    Rigidbody2D _rb;                    // プレイヤーのrigidbody
    Animator _animator;                 // アニメーション切り替え用変数
    String[] _animFlagName;             // アニメーションフラグの名前
    int _animNum = (int)State.Max;      // アニメーションの種類

    /// <summary>
    /// 左右移動用変数
    /// </summary>
    private float _dir;                 // 移動方向(左右)
    private float _runSpeed = 5f;       // 走る速度

    /// <summary>
    /// ジャンプ用変数
    /// </summary>
    private bool _isJumpFlag = false;   // ジャンプしているかどうか
    private float _jumpHeight = 360f;   // ジャンプの高さ

    private bool _isGround = false;     // 地面にいるかどうか// Stateでとればいい
    private ObjectType _type;

    // 初期化
    void Start()
    {
        // 初期状態の設定
        _state = State.Idle;
        this._rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _animFlagName = new String[]{
            "IsIdle",
            "IsRun",
            "IsJumpUp",
            "IsJumpDown"
        };
    }

    void Update()
    {
        // キー入力によって移動を行う
        GetInput();
        Move();
        SetState();
    }

    // 何らかの処理に必要なキー入力の取得
    void GetInput()
    {
        _dir = Input.GetAxisRaw("Horizontal");
        _isJumpFlag = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        // 左右移動
        this._rb.velocity = new Vector2(_runSpeed * _dir, _rb.velocity.y);

        //if (_currentSpeed < _runLimit)
        //{
        //    this._rb.AddForce(transform.right * _dir * _runPower);
        //}
        //else
        //{
            //this.transform.position += new Vector3(Time.deltaTime * _dir * _runSpeed, 0, 0);
       // }

        if(_isGround && _dir == 0)
        {
            this._rb.velocity = new Vector2(0, this._rb.velocity.y);
        }

        // ジャンプ
        if (_isGround && _isJumpFlag)
        {
            this._rb.AddForce(transform.up * _jumpHeight);
            _isGround = false;
        }
    }

    void SetState()
    {
        // 地面
        if(_type == ObjectType.Ground)
        {
            if (_dir == 0)
            {
                _state = State.Idle;
            }
            else
            {
                _state = State.Run;
            }
        }
        // ニードル
        if(_type == ObjectType.Needle)
        {
            // _state = State.Death;
        }
        // 梯子
        if(_type == ObjectType.Ladder)
        {
            //if (_dir == 0)
            //{
            //    _state = State.Climb;
            //}
            //else
            //{
            //    _state = State.Down;
            //}
        }
        // ゴール
        if(_type == ObjectType.Goal)
        {

        }
        // 空中
        else
        {
            _state = State.JumpUp;
        }
        SetAnimInfo((int)_state);
        // 画像の向きを変える
        InverPlayerImage();
    }

    void InverPlayerImage()
    {
        // 画像反転
        var scl = this.transform.localScale;
        if (_dir != 0)
        {
            scl.x = _dir;
        }
        this.transform.localScale = scl;
    }

    void SetAnimInfo(int num)
    {
        bool flag = false;
        for(int i = 0;i < _animNum; i++)
        {
            flag = i == num ? true : false;
            _animator.SetBool(_animFlagName[i], flag);
        }
    }

    // 着地判定
    void OnTriggerEnter2D(Collider2D col)
    {
        _type = col.gameObject.GetComponent<IHitObject>().GetObjectType(col);
    }
    // 空中判定
    private void OnTriggerExit2D(Collider2D col)
    {
        _type = ObjectType.None;
    }
}