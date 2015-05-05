using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.States;
using WindowsGame1.States.AllStates;
using WindowsGame1.Utilities;

namespace WindowsGame1.Physics
{
    class PhysicsObject : DrawObject
    {
        public float angle { get; set; }
        public float speed { get; set; }

        public Vector2 startPos = new Vector2(0, 0);
        public Vector2 velocity = new Vector2(0, 0);
        public float time;
        public float magnitude;


        public PhysicsObject(Texture2D tex)
            : base(tex)
        {

        }
        public void Update(float delta, A2State state)
        {
            time += delta;
            velocity.Y = speed * (float)Math.Sin(angle) + state.gravity * ((speed * (float)Math.Cos(angle)) * time) / (speed * (float)Math.Cos(angle));
            magnitude = (float)Math.Sqrt(Math.Pow(velocity.X, 2) + Math.Pow(velocity.Y, 2));
            //this.rotation = angle;

            // Update regular position
            pos.X = startPos.X - speed * time * (float)Math.Cos(angle);
            pos.Y = startPos.Y + speed * time * (float)Math.Sin(angle) + (state.gravity * (time * time)) / 2;
        }

        // p is the future position of the object after the hit
        public void CalculateHit(Vector2 p, float elasticity)
        {
            float deltaX = p.X - pos.X;
            float deltaY = p.Y - pos.Y;
            angle = (float)Math.Atan2(deltaY, deltaX);
            time = 0;
            speed = magnitude * elasticity;
            velocity.X = speed * (float)Math.Cos(angle);
            velocity.Y = -speed * (float)Math.Sin(angle);
        }
        public void NewDir(float angle, float magnitude)
        {
            this.angle = angle;
            time = 0;
            speed = magnitude * 0.8f;
            velocity.X = speed * (float)Math.Cos(angle);
            startPos = new Vector2(pos.X , pos.Y );
        }

        public float GetVelocityX()
        {
            return velocity.X / A2State.pixelPerMeter;
        }

        public float GetVelocityY()
        {
            return velocity.Y / A2State.pixelPerMeter;
        }

        public Vector2 GetVelocity()
        {
            return new Vector2(GetVelocityX(), GetVelocityY());
        }

    }
}
