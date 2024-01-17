#include "D:\Unreal\Objectif3D_2ANNE\AI_FSM\Source\AI_FSM\DebugLogUtils.h"
#include "IA/WayPoint.h"


AWayPoint::AWayPoint()
{
	PrimaryActorTick.bCanEverTick = true;
#if WITH_EDITOR 
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif
	 icon = CreateDefaultSubobject<UBillboardComponent>("Icon");
	 RootComponent = icon;
}

void AWayPoint::BeginPlay()
{
	Super::BeginPlay();
	Start();
}
void AWayPoint::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	DrawDebug();
}
bool AWayPoint::ShouldTickIfViewportsOnly() const
{
	return shouldTickIfViewportsOnly;
}




void AWayPoint::Start()
{
	shouldTickIfViewportsOnly = false;
	if (allPoints.IsEmpty())
	{
		SCREEN_DEBUG_MESSAGE_ERROR(10, "AWayPoint: No Point");
		return;
	}
	currentAllPoints = allPoints;
	currentPoint = currentAllPoints[0];
}


void AWayPoint::DrawDebug()
{
	
	TArray<APointByWay*> _allPoint;
	if (shouldTickIfViewportsOnly)
	{
		_allPoint = allPoints;
		DrawDebugBox(GetWorld(), GetActorLocation(), FVector(50), FColor::Yellow);
		DrawDebugLine(GetWorld(), GetActorLocation(), _allPoint[0]->GetActorLocation(), FColor::Yellow);
	}
	else
		_allPoint = currentAllPoints;
	
	if (_allPoint.IsEmpty() || _allPoint.Num() < 2)
		return;


	for (size_t i = 0; i < _allPoint.Num() - 1; i++)
	{
		if (_allPoint[i + 1] == nullptr || _allPoint[i] == nullptr)
			return;
		
		DrawDebugSphere(GetWorld(), _allPoint[i]->GetActorLocation(), 100, 32, color);
		DrawDebugSphere(GetWorld(), _allPoint[i + 1]->GetActorLocation(), 100, 32, color);

		DrawDebugLine(GetWorld(), _allPoint[i]->GetActorLocation(), _allPoint[i + 1]->GetActorLocation(), color);
	}
}

void AWayPoint::NextWayPoint()
{
	if (index == currentAllPoints.Num() - 1)
		revers = true;
	else if (index == 0)
		revers = false;


	if (revers)
		index--;
	else
		index++;


	currentPoint = currentAllPoints[index];
}



