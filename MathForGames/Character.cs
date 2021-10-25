using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Character : Actor
    {
        private Vector2 _velocity;
        private float _speed;
        private float _health;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public float Health
        {
            get { return _health; }
        }

        public Character(char icon, float x, float y, float health, float speed, Color color, string name = "Actor")
            : base(icon, x, y, color, name)
        {
            Speed = speed;
            _health = health;
        }

        public override void Start()
        {
            base.Start();
            Forward = new Vector2(1, 0);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            Position += Velocity;

            if (Velocity.Magnitude > 0)
                Forward = Velocity.Normalized;

            if (_health <= 0)
                Engine.RemoveActorFromScene(this);
        }

        public void TakeDamage(float damageAmount)
        {
            _health -= damageAmount;

            if (_health < 0)
                _health = 0;
        }
    }
}