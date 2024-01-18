#include "Kismet/KismetMathLibrary.h"
#include "FSM/FSMComponent.h"
#include "GameMode/BaseGameMode.h"
#include "Manager/IA_GuardManager.h"
#include "3C/PlayableCharacter.h"
#include "D:\Unreal\Objectif3D_2ANNE\AI_FSM\Source\AI_FSM\DebugLogUtils.h"
#include "IA/IA_Guard.h"

#pragma region Constructor
AIA_Guard::AIA_Guard()
{
	PrimaryActorTick.bCanEverTick = true;
#if WITH_EDITOR 
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif
	Init();
}
#pragma endregion

#pragma region UE_METHOD
void AIA_Guard::BeginPlay()
{
	Super::BeginPlay();
	Start();
}
void AIA_Guard::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	DrawDebug();
	Patrol();
}
bool AIA_Guard::ShouldTickIfViewportsOnly() const
{
	return shouldTickIfViewportsOnly;
}
#pragma endregion

#pragma region METHOD
void AIA_Guard::Init()
{
	sphereSightComponent = CreateDefaultSubobject<USphereSightComponent>("SphereSightComponent");
	fsmComponent = CreateDefaultSubobject<UFSMComponent>("FSMComponent");
	guardManagedComponent = CreateDefaultSubobject<UAI_GuardManagedComponent>("GuardManagedComponent");

}
void AIA_Guard::Start()
{
	shouldTickIfViewportsOnly = false;
	if (!wayPoint)
	{
		SCREEN_DEBUG_MESSAGE_ERROR(10, "AIA_Guard: No way");
		return;
	}
	
	guardManagedComponent->Init();
	
	Look();
}
void AIA_Guard::Patrol()
{
	if (!wayPoint)
		return;


	if (!move)
		return;

	if (wayPoint->GetCurrentAllPoints().IsEmpty() || shouldTickIfViewportsOnly)
		return;

	SeeTarget();
	Destination();
	AddMovementInput(GetActorForwardVector(), 1);

}
void AIA_Guard::SeeTarget()
{
	if (currentTarget)
		return;
	if (sphereSightComponent->GetTarget())
		if (Cast<APlayableCharacter>(sphereSightComponent->GetTarget()))
		{
			currentTarget = Cast<APlayableCharacter>(sphereSightComponent->GetTarget());
			hasTarget = true;
			Look();
		}
}
void AIA_Guard::Look()
{
	if (!wayPoint)
		return;

	if (wayPoint->GetCurrentAllPoints().IsEmpty())
		return;
	FRotator _look;
	if (hasTarget)
		_look = UKismetMathLibrary::FindLookAtRotation(GetActorLocation(), currentTarget->GetActorLocation());
	else
		_look = UKismetMathLibrary::FindLookAtRotation(GetActorLocation(), wayPoint->GetCurrentPoint()->GetActorLocation());

	SetActorRotation(_look);
}
void AIA_Guard::ClearTarget()
{
	hasTarget = false;
	move = false;
	sphereSightComponent->CleanTarget();
	currentTarget = nullptr;
	DefineNewPatrol();
}
void AIA_Guard::DefineNewPatrol()
{
	if (!canChangePatrol)
		return;
	SCREEN_DEBUG(5, FColor::Green, "DefineNewPatrol");
	float _currentDistance = FVector::Distance(GetActorLocation(), wayPoint->GetCurrentPoint()->GetActorLocation());
	AIA_Guard* _otherGuard = nullptr;
	ABaseGameMode* _gm = GetWorld()->GetAuthGameMode<ABaseGameMode>();
	if (!_gm)
	{
		GEngine->AddOnScreenDebugMessage(0, 10, FColor::Red, TEXT("AIA_Guard: Not ABaseGameMode "));
		return;
	}

	for (UAI_GuardManagedComponent* _guardInScene : _gm->GetGuardManager()->GetGuardInScene())
	{
		TArray<APointByWay*> allPoints = _guardInScene->GetManaged()->GetCurrentWayPoint()->GetCurrentAllPoints();
		for (int i =0; i < allPoints.Num(); i++)
			if (FVector::Distance(GetActorLocation(), allPoints[i]->GetActorLocation()) < _currentDistance)
			{
				_currentDistance = FVector::Distance(GetActorLocation(), allPoints[i]->GetActorLocation());
				_otherGuard = _guardInScene->GetManaged();
				return;
			}
		
		
	}

	if (_otherGuard)
		wayPoint = _otherGuard->GetCurrentWayPoint();
	
	
}
void AIA_Guard::DrawDebug()
{
	if (!wayPoint)
		return;


	DrawDebugSphere(GetWorld(), GetActorLocation() +GetActorUpVector() * 300, 100, 32, wayPoint->GetColor());
	if (currentTarget)
		DrawDebugSphere(GetWorld(), currentTarget->GetActorLocation(), 100, 32, FColor::Magenta);

	if(shouldTickIfViewportsOnly)
		DrawDebugLine(GetWorld(), GetActorLocation(), wayPoint->GetActorLocation(), FColor::Magenta);
	

}
void AIA_Guard::Destination()
{
	if (!wayPoint)
		return;

	if (hasTarget)
	{
		if (FVector::Distance(GetActorLocation(), currentTarget->GetActorLocation()) >= 500.f)
			ClearTarget();

		return;
	}

	if (FVector::Distance(GetActorLocation(), wayPoint->GetCurrentPoint()->GetActorLocation()) <= 50.f)
	{
		hasDestination = true;
		move = false;
		wayPoint->NextWayPoint();
		Look();
		return;
	}
}
#pragma endregion
