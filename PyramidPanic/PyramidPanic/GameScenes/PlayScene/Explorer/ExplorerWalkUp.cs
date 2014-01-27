//met Using kan je een XNA codebibliotheer gebruiken in je class
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    //Dit is een toestands class (dus moet hij de interface toepassen)
    //Deze class belooft dan plechtig dat hij de methods uit de interface heeft
    public class ExplorerWalkUp : AnimatedSprite, IEntityState
    {
        //fields
        private Explorer explorer;
        private Vector2 velocity;

        //Constructor
        public ExplorerWalkUp(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X,
                                                (int)this.explorer.Position.Y,
                                                32,
                                                32);
            this.velocity = new Vector2(0f, this.explorer.Speed);

        }

        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            if (this.explorer.Position.X > 640 - 32)
            {
                //this.explorer.State = this.explorer.ExplorerWalkLeft;
                //this.explorer.WalkRight.Initialize();
            }

            //Als de Rifht knop wordt losgelatenm dan moet de explorer weer in de toestand idle komen
            if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Initialize();
                this.explorer.WalkDown.Initialize();
                this.explorer.WalkLeft.Initialize();
                this.explorer.WalkRight.Initialize();
            }
            this.explorer.Position -= this.velocity;
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            base.Update(gameTime);
        }


        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}