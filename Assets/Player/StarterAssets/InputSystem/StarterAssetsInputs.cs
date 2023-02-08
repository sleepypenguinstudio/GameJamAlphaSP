using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool interact;
		public bool drop;
		public bool shot;
		public bool reload;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;










       



#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
			
		}

		public void OnInteract(InputValue value)
        {

			InterectInput(value.isPressed);
			//For farhina Apu, just use the interact function here
			Debug.Log("Interect");

        }

		
		public void OnDrop(InputValue value)
        {

			DropInput(value.isPressed);
			Debug.Log("Dropped");
        }

		public void OnFire(InputValue value)
        {
			ShotInput(value.isPressed);
			Debug.Log("Pressed Value");
		}

		public void OnReload(InputValue value)
        {
			ReloadInput(value.isPressed);
        }



#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		
		public void InterectInput(bool newInterectState)
        {
			interact = newInterectState;
        }

		public void DropInput(bool newDropState)
        {
			drop = newDropState;
        }

		public void ShotInput(bool newShotState)
        {
			shot = newShotState;
        }

		public void ReloadInput(bool newReloadState)
        {
			reload = newReloadState;
        }

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}