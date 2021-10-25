using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Bullet : Actor
    {
        private Vector2 _velocity;
        private Actor _owner;
        private float _damage;
        private float _lifeTime;
        private float _despawnTime;

        public Bullet(Vector2 velocity, Vector2 startPosition, float damage, float despawnTime, Actor owner, Color color) : base('o', startPosition.X, startPosition.Y, color,"Bullet")
        {
            _velocity = velocity;
            _owner = owner;
            _damage = damage;
            CollisionRadius = 5;
            _despawnTime = despawnTime;
        }

        public override void OnCollision(Actor actor)
        {
            base.OnCollision(actor);
            //If the target is a charact and isn't the owner of the bullet...
            Character target = actor as Character;
            if (target != null && target != _owner)
                //...damage it
                target.TakeDamage(_damage);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            _lifeTime += deltaTime;

            if (_lifeTime > _despawnTime)
                Engine.RemoveActorFromScene(this);

            Position += _velocity;
        }
    }
}