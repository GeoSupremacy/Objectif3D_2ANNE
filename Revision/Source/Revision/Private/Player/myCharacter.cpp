// Fill out your copyright notice in the Description page of Project Settings.

#include "EnhancedInputSubsystems.h" 
#include "EnhancedInputComponent.h"
#include "Kismet/KismetSystemLibrary.h"
#include "../Utils.h"

#include "Player/myCharacter.h"


#pragma region UE_METHOD
AmyCharacter::AmyCharacter()
{
#if WITH_EDITOR 
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif
	PrimaryActorTick.bCanEverTick = true;
	Init();
}
void AmyCharacter::BeginPlay()
{
	Super::BeginPlay();
	MappingContext();
}
void AmyCharacter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	DrawDebug();
}
void AmyCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);
	BindAction(PlayerInputComponent);
}
bool AmyCharacter::ShouldTickIfViewportsOnly() const
{
	return true;
}
#pragma endregion 

#pragma region Init
void AmyCharacter::Init()
{
	camera = CreateDefaultSubobject<UCameraComponent>("Camera");
	arm = CreateDefaultSubobject<USpringArmComponent>("Arm");
	camera->SetupAttachment(arm);
	arm->SetupAttachment(RootComponent);

	cameralocation = camera->GetRelativeLocation();

	bUseControllerRotationPitch = false;
	bUseControllerRotationRoll = false;
	bUseControllerRotationYaw = false;
}
void AmyCharacter::MappingContext()
{
	if (!inputConfig)
	{
		GEngine->AddOnScreenDebugMessage(0, 10, FColor::Red, TEXT("Not InputConfig "));
		return;
	}
	inputConfig->MappingContext(Cast<APlayerController>(GetController())->GetLocalPlayer());
	
	
	
}
void AmyCharacter::BindAction(UInputComponent* PlayerInputComponent)
{
	UEnhancedInputComponent* _input = Cast<UEnhancedInputComponent>(PlayerInputComponent);
	if (!inputConfig)
		return;

	inputConfig->InitAll();


	if (!inputConfig->IsValid())
	{
		GEngine->AddOnScreenDebugMessage(1, 10, FColor::Red, TEXT("forget one input "));
		return;
	}
	_input->BindAction(inputConfig->StopMovementForwardInput(), ETriggerEvent::Triggered, this, &AmyCharacter::MoveForward);
	_input->BindAction(inputConfig->MovementForwardInput(), ETriggerEvent::Triggered, this, &AmyCharacter::MoveForward);
	_input->BindAction(inputConfig->MovementRightInput(), ETriggerEvent::Triggered, this, &AmyCharacter::MoveRight);
	_input->BindAction(inputConfig->RotatePitchInput(), ETriggerEvent::Triggered, this, &AmyCharacter::RotatePitch);
	_input->BindAction(inputConfig->RotateYawInput(), ETriggerEvent::Triggered, this, &AmyCharacter::RotateYaw);
	_input->BindAction(inputConfig->JumpInput(), ETriggerEvent::Triggered, this, &AmyCharacter::Jump);
	_input->BindAction(inputConfig->EscapeDialogInput(), ETriggerEvent::Triggered, this, &AmyCharacter::EscapeDialog);
	_input->BindAction(inputConfig->InteractInput(), ETriggerEvent::Triggered, this, &AmyCharacter::Interact);
	
}
#pragma endregion 

#pragma region Movement
void AmyCharacter::MoveForward(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddMovementInput(GetActorForwardVector(), _axis);
	onMoveForward.Broadcast(_axis);
}
void AmyCharacter::MoveRight(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddMovementInput(GetActorRightVector(), _axis);
}
void AmyCharacter::RotateYaw(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddControllerYawInput(_axis);
}
void AmyCharacter::RotatePitch(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddControllerPitchInput(_axis);
}
void AmyCharacter::Jump()
{
	bPressedJump = true;
	JumpKeyHoldTime = 0.0f;
}
#pragma endregion 
#include <string.h>
#pragma region Action_Input
void AmyCharacter::Interact()
{
	FHitResult _result;
	FString _id = "";
	
	bool _hit =UKismetSystemLibrary::LineTraceSingleForObjects(this, GetActorLocation(), GetActorLocation() + GetActorForwardVector() * 100, objectLayer, true, TArray<AActor*>(), EDrawDebugTrace::None, _result, true);
	if (_hit && !hasCurrentDialog)
	{
		
		APNJ* _test = nullptr;
		
		
			APNJ* _png = Cast<APNJ>(_result.GetActor());
			if(_png)
				_id = _png->DialogSettings()->GetID();
		
		hasCurrentDialog = true;
		GetWorld()->GetTimerManager().SetTimer(quiteDialog, this, &AmyCharacter::QuitDialog, 1, false);
		
		camera->AddLocalOffset(FVector(100));
		INVOKE(onEnterChat, _id)
		INVOKE(onEnterChatUI, _png)
		INVOKE(onOpenUI)
	}
}
void AmyCharacter::QuitDialog()
{
	GetWorld()->GetTimerManager().ClearTimer(quiteDialog);
	leftDialog = true;
}
void AmyCharacter::EscapeDialog()
{
	if (!leftDialog)
		return;

	 leftDialog = hasCurrentDialog = false;
		camera->AddLocalOffset(FVector(-100));
		INVOKE(onLeftChat)
}
#pragma endregion 

#pragma region Debug
void AmyCharacter::DrawDebug()
{
	FHitResult _result;
	bool _hit = UKismetSystemLibrary::LineTraceSingleForObjects(this, GetActorLocation(), GetActorLocation() + GetActorForwardVector() * 50, objectLayer, true, TArray<AActor*>(), EDrawDebugTrace::None, _result, true);

}
#pragma endregion 