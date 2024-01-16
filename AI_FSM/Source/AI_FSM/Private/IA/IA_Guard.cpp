#include "Kismet/KismetMathLibrary.h"
#include "FSM/FSMComponent.h"
#include "IA/IA_Guard.h"


AIA_Guard::AIA_Guard()
{
 	PrimaryActorTick.bCanEverTick = true;
#if WITH_EDITOR 
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif
	Init();
}


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

void AIA_Guard::Init()
{
	sphereSightComponent = CreateDefaultSubobject<USightSystemComponent>("SphereSightComponent");
	fsmComponent = CreateDefaultSubobject<UFSMComponent>("FSMComponent");
	AddOwnedComponent(sphereSightComponent);
	AddOwnedComponent(fsmComponent);
}

void AIA_Guard::Start()
{
	shouldTickIfViewportsOnly = false;
	if (checkPoints.IsEmpty())
		return;

	currentWayPoint = checkPoints[0];
	Look();
}

void AIA_Guard::Patrol()
{
	if (!move)
		return;

	if (checkPoints.IsEmpty() || shouldTickIfViewportsOnly)
		return;


	if (FVector::Distance(GetActorLocation(), currentWayPoint->GetActorLocation()) <= 50.f)
	{
		hasDestination = true;
		move = false;
		NextWayPoint();
		return;
	}
	AddMovementInput(GetActorForwardVector(), 1);
	
}

void AIA_Guard::Look()
{
	if (checkPoints.IsEmpty())
		return;
	FRotator _look = UKismetMathLibrary::FindLookAtRotation(GetActorLocation(), currentWayPoint->GetActorLocation());

	SetActorRotation(_look);
}
void AIA_Guard::NextWayPoint()
{
	if (index == checkPoints.Num()-1)
		revers = true;
	else if (index == 0)
		revers = false;


	if(revers)
		index--;
	else
		index++;
	
	currentWayPoint = checkPoints[index];
	Look();
}
void AIA_Guard::DrawDebug()
{
	if (checkPoints.IsEmpty() || checkPoints.Num()<2)
		return;
	DrawDebugSphere(GetWorld(), checkPoints[0]->GetActorLocation(), 100, 32, FColor::Red);
	for (size_t i = 0; i < checkPoints.Num()-1; i++)
	{
		if (checkPoints[i + 1] == nullptr || checkPoints[i] == nullptr)
		return;
		DrawDebugSphere(GetWorld(), checkPoints[i]->GetActorLocation(),100, 32, FColor::Red);
		DrawDebugSphere(GetWorld(), checkPoints[i+1]->GetActorLocation(), 100, 32, FColor::Red);
		DrawDebugLine(GetWorld(), checkPoints[i]->GetActorLocation(), checkPoints[i+1]->GetActorLocation(), FColor::Red);
	}
		
	
}

