// (c) Copyright HutongGames, LLC 2010-2017. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Application)]
	[Tooltip("Get the Application Persistent Data Path")]
	public class ApplicationGetPersistentDataPath : FsmStateAction
	{
		
		[RequiredField]
		[Tooltip("The Application Persistent Data Path")]
		[UIHint(UIHint.Variable)]
		public FsmString persistentDataPath;

		[Tooltip("If true, adds a path delimiter '/' at the end of the path")]
		public bool appendPathDelimiter;

		public override void Reset()
		{
			persistentDataPath = null;
			appendPathDelimiter = true;
		}

		public override void OnEnter()
		{
			persistentDataPath.Value = Application.persistentDataPath;

			if (appendPathDelimiter) {
				persistentDataPath.Value += "/";
			}

			Finish();
		}
	}
}