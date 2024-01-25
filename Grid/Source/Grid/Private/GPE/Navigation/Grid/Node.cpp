#include "GPE/Navigation/Grid/GridPointData.h"
#include "\Unreal\Objectif3D_2ANNE\Grid\Source\Grid\Utils.h"
#include "GPE/Navigation/Grid/Node.h"


ANodeGrid::ANodeGrid()
{

	PrimaryActorTick.bCanEverTick = true;
	cube = CREATE(UStaticMeshComponent,"Cube")
	cube->SetStaticMesh(LoadObject<UStaticMesh>(this, TEXT("'/Engine/BasicShapes/Cube.Cube'")));

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
		
		DrawDebugLine(GetWorld(), GetActorLocation(), grid->GetFVectorNodes()[successors[i]], _lineColor);
	}
}