// License: Attribution 4.0 International (CC BY 4.0)
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Material)]
	[Tooltip("Convert a texture to sprite")]
    [HelpUrl("http://hutonggames.com/playmakerforum/index.php?topic=12715.0")]
	public class ConvertTextureToSprite : FsmStateAction
	{
		[ActionSection("Input")]
		[Tooltip("The texture to convert")]
		public FsmTexture texture;
        [Tooltip("Pixels to Unit of the Sprite. Default is 1.")]
        public FsmInt pixelsToUnit;

        [ActionSection("Output")]
		[Tooltip("The sprite object")]
		[UIHint(UIHint.Variable)]
		[ObjectType(typeof(UnityEngine.Sprite))]
		public FsmObject sprite;



		public override void Reset()
		{
			texture = null;
			sprite = null;
            pixelsToUnit = 1;
        }
		
		public override void OnEnter()
		{
			Texture2D temp = (Texture2D) texture.Value;
			Sprite spriteTemp = Sprite.Create(temp, new Rect(0, 0, temp.width,temp.height), new Vector2(.5f, .5f), pixelsToUnit.IsNone ? 1 : pixelsToUnit.Value);
	
			temp = null;

			sprite.Value = (Sprite) spriteTemp;

			spriteTemp = null;

			Finish();
		}


	}
}
