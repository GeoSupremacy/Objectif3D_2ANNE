// Fill out your copyright notice in the Description page of Project Settings.


#include "PlayerCollector.h"
#include "EnhancedInputSubsystems.h"
#include "EnhancedInputComponent.h"
#include "Kismet/KismetSystemLibrary.h"
#include "DebugUtils.h"


#pragma region UE_METHODS
APlayerCollector::APlayerCollector()
{
	PrimaryActorTick.bCanEverTick = true;

	springArm = CreateDefaultSubobject<USpringArmComponent>("Arm");
	camera = CreateDefaultSubobject<UCameraComponent>("Camera");

	springArm->SetupAttachment(RootComponent);
	camera->SetupAttachment(springArm);


	bUseControllerRotationPitch = false;
	bUseControllerRotationRoll = false;
	bUseControllerRotationYaw = false;
}
void APlayerCollector::BeginPlay()
{
	Super::BeginPlay();
	InitInputSystem();
}
void APlayerCollector::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

	UEnhancedInputComponent* _input = Cast<UEnhancedInputComponent>(PlayerInputComponent);
	if (!IsValid())
	{
		SCREEN_DEBUG_MESSAGE_ERROR(1, 10, "Missing input or input Mapping")
		return;
	}
	_input->BindAction(movementForwardInput, ETriggerEvent::Triggered, this, &APlayerCollector::MoveForward);
	_input->BindAction(stopMovementForwardInput, ETriggerEvent::Triggered, this, &APlayerCollector::MoveForward);
	_input->BindAction(movementRightInput, ETriggerEvent::Triggered, this, &APlayerCollector::MoveRight);
	_input->BindAction(movementYawInput, ETriggerEvent::Triggered, this, &APlayerCollector::RotateCameraYaw);
	_input->BindAction(movementPitchInput, ETriggerEvent::Triggered, this, &APlayerCollector::RotateCameraPitch);
	_input->BindAction(jumpInput, ETriggerEvent::Triggered, this, &APlayerCollector::Jump);
	_input->BindAction(interactionInput, ETriggerEvent::Triggered, this, &APlayerCollector::Interact);
	
}
void APlayerCollector::Jump()
{
	bPressedJump = true;
	JumpKeyHoldTime = 0.0f;
	INVOKE(onJump);
}
#pragma endregion

#pragma region CUSTOM_METHOS
void APlayerCollector::InitInputSystem()
{

	APlayerController* _player = GetWorld()->GetFirstPlayerController();

	UEnhancedInputLocalPlayerSubsystem* _iputSystem = ULocalPlayer::GetSubsystem< UEnhancedInputLocalPlayerSubsystem>(_player->GetLocalPlayer());
	_iputSystem->ClearAllMappings();
	_iputSystem->AddMappingContext(inputContext.LoadSynchronous(), 0);
}
void APlayerCollector::MoveForward(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddMovementInput(GetActorForwardVector(), _axis);
	INVOKE(onMoveForward, _axis)
}
void APlayerCollector::MoveRight(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddMovementInput(GetActorRightVector(), _axis);
	INVOKE(onMoveRight, _axis)
}
void APlayerCollector::RotateCameraYaw(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddControllerYawInput(_axis);
}
void APlayerCollector::RotateCameraPitch(const FInputActionValue& _value)
{
	
	const float _axis = _value.Get<float>();
	AddControllerPitchInput(_axis);
}
void APlayerCollector::Ground()
{
	INVOKE(onGround);
}
void APlayerCollector::Interact()
{
	
	INVOKE(onInteract);
}
#pragma endregion
