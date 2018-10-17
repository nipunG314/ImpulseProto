using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ImpulsePrototype {
	class Sprite {
		private Texture2D Texture;
		public Vector2 Location { get; set; }
		public Vector2 Velocity { get; set; }
		private float maxVelocity = 100f;

		public Sprite(Texture2D texture, Vector2 location, float maxSpeed) {
			Texture = texture;
			Location = location;
			Velocity = Vector2.Zero;
			maxVelocity = maxSpeed;
		}

		public void update(Vector2 inputVelocity, float elapsedTime, float frictionCoeff) {
			Velocity = Velocity * frictionCoeff + inputVelocity;
			Location += maxVelocity * Velocity * elapsedTime; 
		}
	}
}
