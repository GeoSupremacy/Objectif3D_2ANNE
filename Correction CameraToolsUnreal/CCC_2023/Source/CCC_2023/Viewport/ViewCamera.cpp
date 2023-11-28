// Fill out your copyright notice in the Description page of Project Settings.


#include "ViewCamera.h"

#include "EnhancedInputSubsystems.h"
#include "EnhancedInputComponent.h"
#include "../Source/CCC_2023/DebugUtils.h"



AViewCamera::AViewCamera()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	RootComponent = CREATE(USceneComponent, "Root");
}
void AViewCamera::BeginPlay()
{
	Super::BeginPlay();
	MappingContext();
	InitInputSystem();
	
}
void AViewCamera::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}



void AViewCamera::MoveTargetWithMouse()
{
	if (!target)
		return;

	FVector _worldLocation, _worldDirection;
	//DEPROJECT_MOUSE_POSITION_TO_WORLD(_worldLocation, _worldDirection)
	PLAYER_CONTROLLER->DeprojectMousePositionToWorld(_worldLocation, _worldDirection);
	target->SetActorLocation(_worldLocation + _worldDirection * dept);

}
void AViewCamera::MoveTargetAtViewportLocation()
{
	if (!target)
		return;

	int _x, _y;
	VIEWPORT_SIZE(_x, _y)
	FVector _worldLocation, _worldDirection;
	float  _xPart = scrennLocation.X * (float)_x,
			_yPart = scrennLocation.X * (float)_y;
	DEPROJECT_SCREEN_POSITION_TO_WORLD(_xPart, _yPart, _worldLocation, _worldDirection)
	//PLAYER_CONTROLLER->DeprojectScreenPositionToWorld(_xPart, _yPart,_worldLocation, _worldDirection);
	target->SetActorLocation(_worldLocation + _worldDirection * dept);

}
void AViewCamera::InitInputSystem()
{
	if (!mouseClikInput)
	{
		SCREEN_DEBUG_MESSAGE_ERROR(0, 10, "AViewCamera => missing input action")
			return;
	}

	UEnhancedInputComponent* _input = Cast<UEnhancedInputComponent>(GetWorld()->GetFirstPlayerController()->InputComponent);
	_input->BindAction(mouseClikInput, ETriggerEvent::Triggered, this, &AViewCamera::Move);
}
void AViewCamera::MappingContext()
{
	
	APlayerController* _player = GetWorld()->GetFirstPlayerController();

	UEnhancedInputLocalPlayerSubsystem* _iputSystem = ULocalPlayer::GetSubsystem< UEnhancedInputLocalPlayerSubsystem>(_player->GetLocalPlayer());
	_iputSystem->ClearAllMappings();
	
	_iputSystem->AddMappingContext(inputContext.LoadSynchronous(), 0);
}
void AViewCamera::Move(const FInputActionValue& _value)
{
	
	MoveTargetWithMouse();
}