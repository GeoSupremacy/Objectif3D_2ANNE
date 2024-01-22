#include "GPE/Navigation/Grid/GridPointData.h"
#include "GPE/Navigation/Grid/Node.h"


ANodeGrid::ANodeGrid()
{

	PrimaryActorTick.bCanEverTick = true;

}


void ANodeGrid::BeginPlay()
{
	Super::BeginPlay();
	
}
void ANodeGrid::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void ANodeGrid::AddSuccessor(int _successor)
{
	successors.Add(_successor);
}

void ANodeGrid::DrawGizmos(FColor _nodeColor, FColor _lineColor)
{
	DrawDebugSphere(GetWorld(),GetActorLocation() ,50, 30, _nodeColor);

	for (int i = 0; IsSelected() && i < successors.Num(); i++)
	{
		//GRID.GET(i) 
		DrawDebugLine(GetWorld(), GetActorLocation(), grid->GetNodes()[successors[i]]->GetActorLocation(), _lineColor);
	}
}