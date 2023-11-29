// Fill out your copyright notice in the Description page of Project Settings.


#include "Diablo/ReworkDiablo/ReworkDiabloCharacter.h"
#include "EnhancedInputSubsystems.h"
#include "EnhancedInputComponent.h"
#include "Kismet/KismetSystemLibrary.h"
#include "Kismet/KismetMathLibrary.h"
#include "GameFramework/CharacterMovementComponent.h"
// Sets default values
AReworkDiabloCharacter::AReworkDiabloCharacter()
{
 	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	camera = CreateDefaultSubobject<UCameraComponent>("Camera");
	springArm = CreateDefaultSubobject<USpringArmComponent>("Arm");

	springArm->SetupAttachment(RootComponent);
	camera->SetupAttachment(springArm);

	AutoPossessPlayer = EAutoReceiveInput::Player0;
}

// Called when the game starts or when spawned
void AReworkDiabloCharacter::BeginPlay()
{
	Super::BeginPlay();
	MappingContext();
}

// Called every frame
void AReworkDiabloCharacter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	MoveTo(DeltaTime);
	DrawDebug();
	MousePosition();
}

// Called to bind functionality to input
void AReworkDiabloCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);
	InitInput(PlayerInputComponent);
}

void AReworkDiabloCharacter::MoveTo(float delta)
{
	if (HasHitToTarget())
		return;
	const FVector _direction = FMath::VInterpConstantTo(GetActorLocation(), destination, delta, GetCharacterMovement()->MaxWalkSpeed);
	SetActorLocation(_direction);
}

void AReworkDiabloCharacter::DrawDebug()
{
	//DRAW_SPHERE_DEF(destination, minRange, 0, Yellow, 12)
	DrawDebugSphere(GetWorld(), destination, minRange, 15, FColor::Yellow, false, -1, 0, 5);
	DrawDebugSphere(GetWorld(), destination, 20, 15, FColor::Green, false, -1, 0, 5);
}

void AReworkDiabloCharacter::MousePosition()
{
	FVector _mousePosition, _mouseDirection;
	GetWorld()->GetFirstPlayerController()->DeprojectMousePositionToWorld(_mousePosition, _mouseDirection);
	DrawDebugSphere(GetWorld(), _mousePosition+ _mouseDirection *300, 10, 15, FColor::Red, false, -1, 0, 5);
}

void AReworkDiabloCharacter::MappingContext()
{
	APlayerController* _player = GetWorld()->GetFirstPlayerController();

	UEnhancedInputLocalPlayerSubsystem* _inputSystem = ULocalPlayer::GetSubsystem<UEnhancedInputLocalPlayerSubsystem>(_player->GetLocalPlayer());
	_inputSystem->ClearAllMappings();

	_inputSystem->AddMappingContext(context.LoadSynchronous(), 0);
}

void AReworkDiabloCharacter::InitInput(UInputComponent* PlayerInputComponent)
{
	UEnhancedInputComponent*  _input = Cast<UEnhancedInputComponent>(PlayerInputComponent);
	_input->BindAction(mouseAction, ETriggerEvent::Triggered, this, &AReworkDiabloCharacter::DefineTarget);

}
void AReworkDiabloCharacter::DefineTarget()
{
	FHitResult _result;
	FVector _mousePosition, _mouseDirection;
	GetWorld()->GetFirstPlayerController()->DeprojectMousePositionToWorld(_mousePosition, _mouseDirection);

	bool _hisHit = UKismetSystemLibrary::LineTraceSingleForObjects(this, _mousePosition, _mousePosition + _mouseDirection * 20000, objectLayer, true, TArray<AActor*>(),EDrawDebugTrace::ForOneFrame , _result, false);

	if (_hisHit)
		destination = _result.ImpactPoint;
}