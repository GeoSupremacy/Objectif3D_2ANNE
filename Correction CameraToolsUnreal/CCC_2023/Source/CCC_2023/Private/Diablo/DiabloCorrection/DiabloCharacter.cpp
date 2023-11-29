// Fill out your copyright notice in the Description page of Project Settings.


#include "Diablo/DiabloCorrection/DiabloCharacter.h"
#include "../Source/CCC_2023/DebugUtils.h"
#include "GameFramework/CharacterMovementComponent.h"
#include "Kismet/KismetSystemLibrary.h"
#include "Kismet/KismetMathLibrary.h"

#include "EnhancedInputSubsystems.h"
#include "EnhancedInputComponent.h"

// Sets default values
ADiabloCharacter::ADiabloCharacter()
{
 	PrimaryActorTick.bCanEverTick = true;
	bUseControllerRotationYaw = false; //Le paw replique sur lui 

	springArm = CreateDefaultSubobject<USpringArmComponent>("Arm");
	camera = CreateDefaultSubobject<UCameraComponent>("Camera");

	springArm->SetupAttachment(RootComponent);
	camera->SetupAttachment(springArm);
	AutoPossessPlayer= EAutoReceiveInput::Player0;
}



void ADiabloCharacter::BeginPlay()
{
	Super::BeginPlay();
	MappingContext();
}
void ADiabloCharacter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	MoveTo(DeltaTime);
	RotateTo(DeltaTime);
	MousePosition();
}
void ADiabloCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);
	InitInputSystem(PlayerInputComponent);
}

void ADiabloCharacter::MoveTo(float _delta)
{
	DRAW_SPHERE_DEF(destination, minRange,0, Yellow, 12)
	//DRAW_CIRCLE(destination, 20, 15, Green)
	DrawDebugSphere(GetWorld(), destination, 20, 15, FColor::Green, false, -1, 0, 5);
	if (IsAsLocation())
		return;
	//const FVector _movement = FMath::VInterpConstantTo(GetActorLocation(), destination, _delta, GetCharacterMovement()->MaxWalkSpeed);
	//SetActorLocation(_movement);
	FVector _direction = destination - GetActorLocation();
	AddMovementInput(_direction.GetSafeNormal(), 1);
}
void ADiabloCharacter::GetTargetLocation(const FInputActionValue& _value)
{
	FVector _mousePosition, _mouseRotation;
	DEPROJECT_MOUSE_POSITION_TO_WORLD(_mousePosition, _mouseRotation)
	FHitResult _result;
	bool _hisHit = UKismetSystemLibrary::LineTraceSingleForObjects(this, _mousePosition,
		_mousePosition+ _mouseRotation * 20000, objectLayer, true, actorToIgnore, EDrawDebugTrace::None, _result, true);

	if (_hisHit)
		destination = _result.ImpactPoint;
}
void ADiabloCharacter::InitInputSystem(UInputComponent* PlayerInputComponent)
{
	UEnhancedInputComponent* _input = Cast<UEnhancedInputComponent>(PlayerInputComponent);

	_input->BindAction(mouseClikInput, ETriggerEvent::Triggered, this, &ADiabloCharacter::GetTargetLocation);

}
void ADiabloCharacter::MappingContext()
{
	APlayerController* _player = GetWorld()->GetFirstPlayerController();

	UEnhancedInputLocalPlayerSubsystem* _inputSystem = ULocalPlayer::GetSubsystem< UEnhancedInputLocalPlayerSubsystem>(_player->GetLocalPlayer());
	_inputSystem->ClearAllMappings();

	_inputSystem->AddMappingContext(inputContext.LoadSynchronous(), 0);
}
void ADiabloCharacter::RotateTo(float _delta)
{
	/*
	FRotator _look = UKismetMathLibrary::FindLookAtRotation(GetActorLocation(), destination);

	_look.Roll = 0;
	_look.Pitch = 0;
	const FRotator rot = FMath::RInterpConstantTo(GetActorRotation(), _look, _delta, 500);
	SetActorRotation(rot);
	*/
	FVector _direction = destination - GetActorLocation();
	AddControllerYawInput(FVector::DotProduct(_direction.GetSafeNormal(), GetActorRightVector()));
}

void ADiabloCharacter::MousePosition()
{
	FVector _x, _y;
	DEPROJECT_MOUSE_POSITION_TO_WORLD(_x, _y)
	DRAW_SPHERE(_x + _y * 300, 0.5f, Red, 2)
}
