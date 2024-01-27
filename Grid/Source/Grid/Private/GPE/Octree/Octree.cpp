#include "\Unreal\Objectif3D_2ANNE\Grid\Source\Grid\Utils.h"
#include "GPE/Octree/OctreeCell.h"
#include "NavigationSystem.h"
#include "GPE/Octree/Octree.h"


AOctree::AOctree()
{
 	PrimaryActorTick.bCanEverTick = true;
#if WITH_EDITOR 
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif

	RootComponent = CREATE(USceneComponent, "Root");
}




void AOctree::BeginPlay()
{
	Super::BeginPlay();
	
}
void AOctree::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}
bool AOctree::ShouldTickIfViewportsOnly() const
{
	return shouldTickIfViewportsOnly;
}

void AOctree::InitRootCell()
{
	if (!root) return;
	UNavigationSystemV1* _nav = UNavigationSystemV1::GetCurrent(GetWorld());
	if (!_nav) return;
	FVector _navigableBounds = _nav->GetNavigableWorldBounds().GetExtent();
	FTimerHandle _timer;
	FTimerDelegate _delegate;
	_delegate.BindUObject(root, &AOctreeCell::SetCellDimensions, _navigableBounds.X, _navigableBounds.Y, _navigableBounds.Z);
	GetWorld()->GetTimerManager().SetTimer(_timer, _delegate, 2.1f, false, .1f);
	root->AttachToActor(this, FAttachmentTransformRules::SnapToTargetIncludingScale);
	root->SetOctree(this);
}
void AOctree::GenerateOctree()
{
	if (root) return;
	root = GetWorld()->SpawnActor<AOctreeCell>(cellToSPawn, GetActorLocation(), FRotator::ZeroRotator);

	if (!root)
	{
		SCREEN_DEBUG_MESSAGE_ERROR(10, "Not instanciate root");
		return;
	}
	InitRootCell();
}
void AOctree::DestroyOctree()
{
	if (!root)return;
	root->CustomDestroy();
	Destroy();
}

