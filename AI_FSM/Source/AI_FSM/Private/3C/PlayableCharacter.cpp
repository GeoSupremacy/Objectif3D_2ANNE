#include "GameFramework/CharacterMovementComponent.h"
#include "Kismet/KismetMathLibrary.h"
#include "3C/PlayableCharacter.h"

#pragma region Constructeur
APlayableCharacter::APlayableCharacter()
{
#if WITH_EDITOR 
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif
	PrimaryActorTick.bCanEverTick = true;
	Init();
}
#pragma endregion

#pragma region METHOD_UNREAL
void APlayableCharacter::BeginPlay()
{
	Super::BeginPlay();
	MappingContext();
}
void APlayableCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);
	BindInput(PlayerInputComponent);
}
bool APlayableCharacter::ShouldTickIfViewportsOnly() const
{
	return shouldTickIfViewportsOnly;
}
#pragma endregion

#pragma region INPUT_METHOD
void APlayableCharacter::Init()
{
	springArm = CreateDefaultSubobject<USpringArmComponent>("Arm");
	camera = CreateDefaultSubobject<UCameraComponent>("Camera");

	
	springArm->SetupAttachment(RootComponent);
	camera->SetupAttachment(springArm);

	bUseControllerRotationPitch = false;
	bUseControllerRotationRoll = false;
	bUseControllerRotationYaw = false;
}
void APlayableCharacter::MappingContext()
{
	if (!inputConfig)
	{
		GEngine->AddOnScreenDebugMessage(0, 10, FColor::Red, TEXT("Not InputConfig "));
		return;
	}
	inputConfig->EnableInputContext(Cast<APlayerController>(GetController())->GetLocalPlayer());
}
void APlayableCharacter::BindInput(UInputComponent* PlayerInputComponent)
{
	UEnhancedInputComponent* _input = Cast<UEnhancedInputComponent>(PlayerInputComponent);
	if (!inputConfig)
		return;
	if (!inputConfig->InputIsValid())
	{
		GEngine->AddOnScreenDebugMessage(1, 10, FColor::Red, TEXT("forget one input "));
		return;
	}
	CheckInput();
	_input->BindAction(inputConfig->InputMoveForward(), ETriggerEvent::Triggered, this, &APlayableCharacter::MoveForward);
	_input->BindAction(inputConfig->InputStopMoveForward(), ETriggerEvent::Triggered, this, &APlayableCharacter::MoveForward);
	_input->BindAction(inputConfig->InputMoveRight(), ETriggerEvent::Triggered, this, &APlayableCharacter::MoveRight);
	_input->BindAction(inputConfig->InputStopMoveForward(), ETriggerEvent::Triggered, this, &APlayableCharacter::MoveRight);
}
void APlayableCharacter::CheckInput()
{
	

	inputConfig->InitArray();
	
}
#pragma endregion

#pragma region MOVEMENT
void APlayableCharacter::MoveForward(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	vAxis = _axis;
	
	FVector _fwd = FRotator(0, GetControlRotation().Yaw, 0).Quaternion() * FVector(1, 0, 0);
	
	AddMovementInput(_fwd, _axis);
	RotateCameraYaw();
	vAxis = vAxis > 0 ? vAxis : -1 - vAxis;
	onMoveForward.Broadcast(_axis);
}
void APlayableCharacter::MoveRight(const FInputActionValue& _value)
{
	const float _axis = _value.Get<float>();
	hAxis = _axis;
	
	FVector _horizontal = FRotator(0, GetControlRotation().Yaw, GetControlRotation().Roll).Quaternion() * FVector(0, 1, 1);
	
	AddMovementInput(_horizontal, _axis);
	RotateCameraYaw();
	hAxis = hAxis > 0 ? hAxis : -1 - hAxis;
	//onMoveForward.Broadcast(_axis);
}
void APlayableCharacter::RotateCameraYaw()
{
	if (FMath::Abs(vAxis) > 0 && GetVelocity().Size() < GetCharacterMovement()->MaxWalkSpeed)
		return;
	FRotator _look = UKismetMathLibrary::FindLookAtRotation(GetActorLocation(), FVector(GetDeltaV().X, GetDeltaV().Y, 0));
	

	
	if (hAxis == 0 && vAxis == 0)
	{
		deltaV = FVector(0);
		return;
	}
	
	_look.Roll = 0;
	_look.Pitch = 0;

	SetActorRotation(_look);
}
#pragma endregion
