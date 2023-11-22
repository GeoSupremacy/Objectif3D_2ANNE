// Fill out your copyright notice in the Description page of Project Settings.


#include "PawnInputComponent.h"
#include "EnhancedInputSubsystems.h"
#include "EnhancedInputComponent.h"
#include "Kismet/KismetSystemLibrary.h"


// Sets default values
APawnInputComponent::APawnInputComponent()
{
 	// Set this pawn to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	RootComponent = CreateDefaultSubobject<USceneComponent>("Root");

}
void APawnInputComponent::BeginPlay()
{
	Super::BeginPlay();
	InitInputSystem();
}
void APawnInputComponent::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}
void APawnInputComponent::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);
	UEnhancedInputComponent* _input =Cast<UEnhancedInputComponent>(PlayerInputComponent);

	_input->BindAction(movementInput, ETriggerEvent::Triggered, this, &APawnInputComponent::MoveForward);
}

void APawnInputComponent::InitInputSystem()
{
	APlayerController* _player = GetWorld()->GetFirstPlayerController();

	UEnhancedInputLocalPlayerSubsystem* _iputSystem = ULocalPlayer::GetSubsystem< UEnhancedInputLocalPlayerSubsystem>(_player->GetLocalPlayer());
	_iputSystem->ClearAllMappings();
	_iputSystem->AddMappingContext(inputContext.LoadSynchronous(), 0);
}

void APawnInputComponent::MoveForward(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	UKismetSystemLibrary::PrintString(this, FString::SanitizeFloat(_axis));
}

