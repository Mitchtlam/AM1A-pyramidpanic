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
    public class Explorer : IAnimatedSprite
    {
        //fields
        private PyramidPanic game;
        private IEntityState state;
        private Texture2D texture;
        private int speed = 3;
        private Vector2 position;
        private ExplorerIdle idle;

        //Maak van iedere toestand (state) een field
        private ExplorerWalkUp walkUp;
        private ExplorerWalkDown walkDown;
        private ExplorerWalkLeft walkLeft;
        private ExplorerWalkRight walkRight;


        //propperties
        public IEntityState State
        {
            set { this.state = value; }
        }
        public ExplorerIdle Idle
        {
            get { return this.idle; }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public int Speed
        {
            get { return this.speed; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public ExplorerWalkDown WalkDown
        {
            get { return this.walkDown; }
        }
        public ExplorerWalkUp WalkUp
        {
            get { return this.walkUp; }
        }
        public ExplorerWalkRight WalkRight
        {
            get { return this.walkRight; }
        }
        public ExplorerWalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }



        //constructor
        public Explorer(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(@"explorer/Explorer");
            this.walkUp = new ExplorerWalkUp(this);
            this.walkDown = new ExplorerWalkDown(this);
            this.walkRight = new ExplorerWalkRight(this);
            this.walkLeft = new ExplorerWalkLeft(this);
            this.idle = new ExplorerIdle(this);
            this.state = this.idle;

        }



        //update
        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }


        //draw
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
        }
    }
}