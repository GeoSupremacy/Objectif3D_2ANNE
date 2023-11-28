// Fill out your copyright notice in the Description page of Project Settings.


#include "CharacterMouse.h"


#include "../Source/CCC_2023/DebugUtils.h"
#include "Kismet/KismetSystemLibrary.h"
#include "Kismet/KismetMathLibrary.h"
#include "EnhancedInputSubsystems.h"
#include "EnhancedInputComponent.h"
#include "GameFramework/CharacterMovementComponent.h"

#pragma region Constructeur
ACharacterMouse::ACharacterMouse()
{
	PrimaryActorTick.bCanEverTick = true;

	springArm = CreateDefaultSubobject<USpringArmComponent>("Arm");
	camera = CreateDefaultSubobject<UCameraComponent>("Camera");

	springArm->SetupAttachment(RootComponent);
	camera->SetupAttachment(springArm);

	bUseControllerRotationPitch = false;
	bUseControllerRotationRoll = false;
	//bUseControllerRotationYaw = false;

}
#pragma endregion Constructeur


#pragma region METHODE_UE
void ACharacterMouse::BeginPlay()
{
	Super::BeginPlay();
	MappingContext();
}
void ACharacterMouse::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	DRAW_LINE(GetActorLocation(), GetActorLocation() + GetActorForwardVector() * 300, Red,5);
	Target();
	MousePosition();
	MoveToTarget();
}
void ACharacterMouse::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);
	InitInputSystem(PlayerInputComponent);
	
}
#pragma endregion METHODE_UE

#pragma region Movement
void ACharacterMouse::InitInputSystem(UInputComponent* PlayerInputComponent)
{
	UEnhancedInputComponent* _input = Cast<UEnhancedInputComponent>(PlayerInputComponent);
	
	_input->BindAction(mouseClikInput, ETriggerEvent::Triggered, this, &ACharacterMouse::MoveForward);
}
void ACharacterMouse::MappingContext()
{
	APlayerController* _player = GetWorld()->GetFirstPlayerController();

	UEnhancedInputLocalPlayerSubsystem* _inputSystem = ULocalPlayer::GetSubsystem< UEnhancedInputLocalPlayerSubsystem>(_player->GetLocalPlayer());
	_inputSystem->ClearAllMappings();

	_inputSystem->AddMappingContext(inputContext.LoadSynchronous(), 0);
}
void ACharacterMouse::MoveForward(const FInputActionValue& _value)
{
	DEPROJECT_MOUSE_POSITION_TO_WORLD(location, direction)
	hasTarget = true;
	distance = FVector::Dist(location, GetActorLocation());
	
	RotateCameraYaw();
}
void ACharacterMouse::MoveToTarget()
{
	if (!hasTarget)
	{
		vAxis = 0;
		return;
	}
	AddMovementInput(GetActorLocation(), 1);
	if (distance <= 0.5f)
		hasTarget = false;
	
	
	
}
void ACharacterMouse::RotateCameraYaw()
{
	
	FRotator _look = UKismetMathLibrary::FindLookAtRotation(GetActorLocation(), positionTarget);

	_look.Roll = 0;
	_look.Pitch = 0;

	SetActorRotation(_look);
}
void ACharacterMouse::MousePosition()
{
	FVector _x, _y;
	DEPROJECT_MOUSE_POSITION_TO_WORLD(_x, _y)
	DRAW_SPHERE(_x + _y * 300, 0.5f, Red, 2)
}
void ACharacterMouse::Target()
{
	FHitResult _result;
	bool _isHit = UKismetSystemLibrary::LineTraceSingleForObjects(GetWorld(), location, location + direction * 2000, objectLayer, true, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, _result, false);
	if (_isHit)
		positionTarget = FVector(_result.ImpactPoint.X, _result.ImpactPoint.Y, _result.ImpactPoint.Z + 0.5);
	DRAW_SPHERE(positionTarget, 50, Red, 2)
}
#pragma endregion Movement
