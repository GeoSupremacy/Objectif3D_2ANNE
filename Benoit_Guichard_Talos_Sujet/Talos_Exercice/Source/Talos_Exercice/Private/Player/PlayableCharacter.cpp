// Fill out your copyright notice in the Description page of Project Settings.


#include "GPE/Reflector.h"
#include "../DebugUtils.h"
#include "../Utils.h"
#include "../DrawDebugUtils.h"
#include "Player/PlayableCharacter.h"


#pragma region Constructor
APlayableCharacter::APlayableCharacter()
{
	PrimaryActorTick.bCanEverTick = true;
#if WITH_EDITOR 
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif
	Init();
}
#pragma endregion

#pragma region UNREAL_METHOD
bool APlayableCharacter::ShouldTickIfViewportsOnly() const
{
	return shouldTickIfViewportsOnly;
}
void APlayableCharacter::BeginPlay()
{
	Super::BeginPlay();
	MappingContect();
	Bind();
}
void APlayableCharacter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	FlagInteract();
}
void APlayableCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);
	BindInput(PlayerInputComponent);
}
#pragma endregion

#pragma region INPUT_METHOD
void APlayableCharacter::MappingContect()
{
	if (!inputConfig)
	{
		SCREEN_DEBUG_MESSAGE_ERROR(10, "APlayableCharacter not define input");
		return;
	}
	
	inputConfig->EnableInputContext(Cast<APlayerController>(GetController())->GetLocalPlayer());
}
void APlayableCharacter::BindInput(UInputComponent* PlayerInputComponent)
{
	UEnhancedInputComponent* _input = Cast<UEnhancedInputComponent>(PlayerInputComponent);

	if (!inputConfig)
		return;
	if (!interact)
	{
		SCREEN_DEBUG_MESSAGE_ERROR(5, "APlayableCharacter not interactComponent")
			return;
	}
	inputConfig->InitArray();

	if (!inputConfig->InputIsValid() || !inputConfig->HasInputContext())
	{
		SCREEN_DEBUG_MESSAGE_ERROR(10, "APlayableCharacter not input action or context");
		return;
	}
	
	_input->BIND_ACTION(inputConfig->InputMoveForward(), this, &APlayableCharacter::MoveForward)
	_input->BIND_ACTION(inputConfig->InputStopMoveForward(), this, &APlayableCharacter::MoveForward)
	_input->BIND_ACTION(inputConfig->InputInteract(), this, &APlayableCharacter::Link)
	_input->BIND_ACTION(inputConfig->MouseRotateYaw(), this, &APlayableCharacter::MouseRotateYaw)
	_input->BIND_ACTION(inputConfig->MouseRotatePitch(), this, &APlayableCharacter::MouseRotatePitch)
	_input->BIND_ACTION(inputConfig->InputRotateYaw(), this, &APlayableCharacter::InputRotateYaw)
	_input->BIND_ACTION(inputConfig->InputResetAllLinkReflector(), this, &APlayableCharacter::ResetAllLink)
	_input->BIND_ACTION(inputConfig->InputInteract(), interact.Get(), &UInteractComponent::Grab)
	_input->BIND_ACTION(inputConfig->InputDrop(), interact.Get(), &UInteractComponent::Drop)

}
#pragma endregion

#pragma region UI
void APlayableCharacter::EnableIcone()
{
	INVOKE(onEnable);
	hasObject = true;
}
void APlayableCharacter::DisableIcone()
{
	INVOKE(onDisable);
	canLink =hasObject = false;
}

#pragma endregion

#pragma region INIT
void APlayableCharacter::Init()
{
	camera = CREATE(UCameraComponent, "Camera")
	springArm = CREATE(USpringArmComponent, "Arm")
	interact = CREATE(UInteractComponent, "Interact")

	ATTACH_TO(camera, springArm)
	ATTACH_TO(springArm, RootComponent)
	AddOwnedComponent(interact);
	//Prend le contole du personnage
	springArm->bUsePawnControlRotation = true;
	//Désactive le controle du personnage
	bUseControllerRotationPitch = false;
	bUseControllerRotationRoll = false;
}
void APlayableCharacter::Bind()
{
	if (!interact)
		return;

		interact->OnGrab().AddDynamic(this, &APlayableCharacter::EnableIcone);
	    interact->OnDrop().AddDynamic(this, &APlayableCharacter::DisableIcone);
}
#pragma endregion

#pragma region MOVEMENT
void APlayableCharacter::MoveForward(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	
	AddMovementInput(GetActorForwardVector(), _axis);
	INVOKE(onMoveForward, _axis);
}
void APlayableCharacter::InputRotateYaw(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddControllerYawInput(_axis);
}
void APlayableCharacter::MouseRotatePitch(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddControllerPitchInput(_axis);
}
void APlayableCharacter::MouseRotateYaw(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	AddControllerYawInput(_axis);
}
void APlayableCharacter::Link(const FInputActionValue& _value)
{
	if (!canLink)
		return;

	SCREEN_DEBUG_MESSAGE_WARNING(5,"Link")
	
		
	INVOKE(onInteract,true);
}
void APlayableCharacter::ResetAllLink(const FInputActionValue& _value)
{
	//TODO REST REFLECTOR
}
#pragma endregion

#pragma region DrawDebug
void APlayableCharacter::FlagInteract()
{
	if (!canLink)
		return;

	DRAW_SPHERE(GetActorLocation() + GetActorUpVector() * 200,25,FColor::Green,2);
}
#pragma endregion