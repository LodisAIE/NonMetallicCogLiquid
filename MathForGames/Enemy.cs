using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Enemy : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Actor _target;
        private float _maxSightDistance;
        public UIText SpeechText;
        private float _maxViewAngle;
        

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

        public Enemy(char icon, float x, float y, float speed, float maxSightDistance, float maxViewAngle, Color color, Actor target, string name = "Actor")
            : base(icon, x, y, color, name)
        {
            _speed = speed;
            _target = target;
            _maxSightDistance = maxSightDistance;
            _maxViewAngle = maxViewAngle;
        }


        public override void Start()
        {
            base.Start();
        }

        public override void Update(float deltaTime)
        {
            SpeechText.Text = "Pls get away";
            SpeechText.Position = Position + new Vector2(0, -5);
            //Create a vector that stores the move input
            Vector2 moveDirection = (_target.Position - Position).Normalized;

            Velocity = moveDirection * Speed * deltaTime;

            if (GetTargetInSight())
                Position += Velocity;

            base.Update(deltaTime);
        }

        public bool GetTargetInSight()
        {
            Vector2 directionOfTarget = (_target.Position - Position).Normalized;
            float distanceToTarget = Vector2.Distance(_target.Position, Position);

            float dotProduct = Vector2.DotProduct(directionOfTarget, Forward);

            return MathF.Acos(dotProduct) < _maxViewAngle && distanceToTarget < _maxSightDistance;
        }

        public override void OnCollision(Actor actor)
        {
            Console.WriteLine("Collision occured");
        }
    }
}
