
#include "\Unreal\Objectif3D_2ANNE\Grid\Source\Grid\DebugLogUtils.h"
#include "\Unreal\Objectif3D_2ANNE\Grid\Source\Grid\Utils.h"
#include "3C/MyCharacter.h"


AMyCharacter::AMyCharacter()
{
 	
	PrimaryActorTick.bCanEverTick = true;
	Init();
}


void AMyCharacter::BeginPlay()
{
	Super::BeginPlay();
	MappingContect();
}
void AMyCharacter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}
void AMyCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);
	BindInput(PlayerInputComponent);
}



void AMyCharacter::MappingContect()
{
	if (desactivateInput)
	{
		SCREEN_DEBUG_MESSAGE_WARNING(10, "Desactivate input");
		return;
	}
	if (!inputConfig)
	{
		SCREEN_DEBUG_MESSAGE_ERROR(10, "APlayableCharacter not define input");
		return;
	}

	inputConfig->EnableInputContext(Cast<APlayerController>(GetController())->GetLocalPlayer());
}
void AMyCharacter::BindInput(UInputComponent* PlayerInputComponent)
{
	if (desactivateInput)
		return;

	UEnhancedInputComponent* _input = Cast<UEnhancedInputComponent>(PlayerInputComponent);

	if (!CheckInput())
		return;

			_input->BIND_ACTION(inputConfig->MovementForwardInput(), this, &AMyCharacter::MoveForward)
			_input->BIND_ACTION(inputConfig->MovementStopForwardInput(), this, &AMyCharacter::MoveForward)
			_input->BIND_ACTION(inputConfig->RotatePitchInput(), this, &AMyCharacter::MouseRotatePitch)
			_input->BIND_ACTION(inputConfig->RotateYawInput(), this, &AMyCharacter::MouseRotateYaw)
			_input->BIND_ACTION(inputConfig->MovementRightInput(), this, &AMyCharacter::MoveRight)
			_input->BIND_ACTION(inputConfig->MovementStopRightInput(), this, &AMyCharacter::MoveRight)
}
bool AMyCharacter::CheckInput()
{
	if (!inputConfig->InputIsValid() || !inputConfig->HasInputContext() || !inputConfig)
	{
		SCREEN_DEBUG_MESSAGE_ERROR(10, "APlayableCharacter not input action or context");
		return false;
	}

	
	return true;
}
void AMyCharacter::Init()
{
		camera = CREATE(UCameraComponent, "Camera")
		springArm = CREATE(USpringArmComponent, "Arm")

		ATTACH_TO(camera, springArm)
		ATTACH_TO(springArm, RootComponent)
	
	springArm->bUsePawnControlRotation = true;
	
	bUseControllerRotationPitch = false;
	bUseControllerRotationRoll = false;
}




void AMyCharacter::MoveForward(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();

	AddMovementInput(GetActorForwardVector(), _axis);
	INVOKE(onMoveForward, _axis);
}
void AMyCharacter::MoveRight(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();

	AddMovementInput(GetActorRightVector(), _axis);
	
}
void AMyCharacter::MouseRotatePitch(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddControllerPitchInput(_axis);
}
void AMyCharacter::MouseRotateYaw(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddControllerYawInput(_axis);
}

