// Fill out your copyright notice in the Description page of Project Settings.


#include "CharacterCollectorCorrection.h"
#include "EnhancedInputComponent.h"
#include "../Source/CCC_2023/DebugUtils.h"
#include "Kismet/KismetSystemLibrary.h"

ACharacterCollectorCorrection::ACharacterCollectorCorrection()
{
 	
	PrimaryActorTick.bCanEverTick = true;

	
	springArm = CreateDefaultSubobject<USpringArmComponent>("ArmCorrection");
	camera = CreateDefaultSubobject<UCameraComponent>("CameraCorrection");

	springArm->SetupAttachment(RootComponent);
	camera->SetupAttachment(springArm);
	

	interact = CreateDefaultSubobject<UInteractComponentCorrection>("InputComponent");
	AddOwnedComponent(interact);

	bUseControllerRotationPitch = false;
	bUseControllerRotationRoll = false;
	bUseControllerRotationYaw = false;
}
void ACharacterCollectorCorrection::BeginPlay()
{
	Super::BeginPlay();
	
}
void ACharacterCollectorCorrection::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}
void ACharacterCollectorCorrection::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);
	if (!inputConfig)
	{
		LOG_ERROR("ACharacterCollectorCorrection: missing DataInput");
		return;
	}

	
	inputConfig->EnableInputContext(Cast<APlayerController>(GetController())->GetLocalPlayer());
	UEnhancedInputComponent* _input = Cast<UEnhancedInputComponent>(PlayerInputComponent);
	if (!_input)
	{
		LOG_ERROR("ACharacterCollectorCorrection: missing input UEnhancedInputComponent");
		return;
	}

	if (!inputConfig->IsValid())
	{
		LOG_ERROR("UInputConfig: missing Mapping Axe or action");
		return;
	}

	_input->BindAction(inputConfig->MovementForwardInput(), ETriggerEvent::Triggered, this, &ACharacterCollectorCorrection::MoveForward);
	_input->BindAction(inputConfig->RotateInput(), ETriggerEvent::Triggered, this, &ACharacterCollectorCorrection::RotateCharacter);
	_input->BindAction(inputConfig->ActionInput(), ETriggerEvent::Triggered, interact.Get(), &UInteractComponentCorrection::GrabObject);
	_input->BindAction(inputConfig->ActionInput(), ETriggerEvent::Triggered, interact.Get(), &UInteractComponentCorrection::DropObject);
}
void ACharacterCollectorCorrection::MoveForward(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddMovementInput(GetActorForwardVector(), _axis);
}

void ACharacterCollectorCorrection::RotateCharacter(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddControllerYawInput( _axis);
}

