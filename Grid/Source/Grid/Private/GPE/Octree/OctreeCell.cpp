#include "\Unreal\Objectif3D_2ANNE\Grid\Source\Grid\Utils.h"
#include "GPE/Octree/Octree.h"
#include "GPE/Octree/OctreeCell.h"

AOctreeCell::AOctreeCell()
{
 	PrimaryActorTick.bCanEverTick = true;
#if WITH_EDITOR 
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif
	RootComponent = CREATE(USceneComponent, "Root");
	box = CREATE(UBoxComponent, "Box");
	box->SetupAttachment(RootComponent);
}




void AOctreeCell::BeginPlay()
{
	Super::BeginPlay();
	onNumberOfActorInsideUpdate.AddDynamic(this, &AOctreeCell::ManageCellBehaviour);
}
void AOctreeCell::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	DrawDebug();
}

bool AOctreeCell::ShouldTickIfViewportsOnly() const
{
	return shouldTickIfViewportsOnly;
}
void AOctreeCell::NotifyActorBeginOverlap(AActor* OtherActor)
{
	Super::NotifyActorBeginOverlap(OtherActor);
	const int _size = classToDetect.Num();

	for (size_t i = 0; i < _size; i++)
	{
		if (classToDetect[i].GetDefaultObject()->StaticClass() == OtherActor->StaticClass())
		{
			currentActorInside++;
			actorInside.Add(OtherActor);
		}
	}
	INVOKE(onNumberOfActorInsideUpdate, currentActorInside)
}
void AOctreeCell::NotifyActorEndOverlap(AActor* OtherActor)
{
	Super::NotifyActorEndOverlap(OtherActor);

	const int _size = classToDetect.Num();

	for (size_t i = 0; i < _size; i++)
	{
		if (classToDetect[i].GetDefaultObject()->StaticClass() == OtherActor->StaticClass())
		{
			currentActorInside--;
			actorInside.Remove(OtherActor);
		}
	}
	INVOKE(onNumberOfActorInsideUpdate, currentActorInside)
}
void AOctreeCell::InitSubCell(const int _branchID, AOctree* _octree, AOctreeCell* _parent)
{
	brancheID = _branchID +1;
	octree = _octree;
	parent = _parent;
}
void AOctreeCell::SubDivideCells(const FVector _subLoction)
{
	AOctreeCell* _subCell = GetWorld()->SpawnActor<AOctreeCell>(octree->GetCellToSPawn(), GetActorLocation(), FRotator::ZeroRotator);

	if (!_subCell)return;
	_subCell->InitSubCell(brancheID, octree, this);
	_subCell->AttachToActor(this, FAttachmentTransformRules::KeepRelativeTransform);
	_subCell->box->SetBoxExtent(box->GetScaledBoxExtent() / 2);
	_subCell->SetActorLocation(_subLoction);
	cellChildren.Add(_subCell);
	currentNumberOfChildren++;
}
void AOctreeCell::RemoveCells()
{
	if (brancheID < 2)return;
	for (size_t i = 0; i < currentNumberOfChildren; i++)
	{
		AOctreeCell* _cell = cellChildren[i];
		if (!_cell) continue;
		_cell->CustomDestroy();


	}
	cellChildren.Empty();
	currentNumberOfChildren = 0;
}
void AOctreeCell::ManageCellBehaviour(const int _numberOfActorInside)
{
	if (!octree) return;
	if (_numberOfActorInside >= cellParameters.capacity && currentNumberOfChildren < 1 &&
		brancheID < octree->GetMaxBrancheID())
	{
		for (size_t i = 0; i < cellParameters.childrenNumberCapacity; i++)
		{
			const FVector _subLoc = GetSubLocation(i);
			SubDivideCells(_subLoc);
		}
	}
		
}
FVector AOctreeCell::GetSubLocation(const int _index)
{
	float _x = 0, _y = 0, _z = 0;
	if (_index > 4)
	{
		_x = _index == 0 || _index == 2 ? box->Bounds.Origin.X + box->Bounds.BoxExtent.X / 2 :
										  box->Bounds.Origin.X - box->Bounds.BoxExtent.X / 2;

		_y = _index == 0 || _index == 1 ? box->Bounds.Origin.Y + box->Bounds.BoxExtent.Y / 2 :
										  box->Bounds.Origin.Y - box->Bounds.BoxExtent.Y / 2;

		_z =  box->Bounds.Origin.Z + box->Bounds.BoxExtent.Z / 2;
	}
	else
	{
		_x = _index == 4 || _index == 6 ? box->Bounds.Origin.X + box->Bounds.BoxExtent.X / 2 :
			box->Bounds.Origin.X - box->Bounds.BoxExtent.X / 2;

		_y = _index == 4 || _index == 5 ? box->Bounds.Origin.Y + box->Bounds.BoxExtent.Y / 2 :
			box->Bounds.Origin.Y - box->Bounds.BoxExtent.Y / 2;

		_z = box->Bounds.Origin.Z - box->Bounds.BoxExtent.Z / 2;
	}
	return FVector(_x , _y , _z);
}

void AOctreeCell::DrawDebug()
{
	if (!useDebug) return;
	DRAW_BOX(box->Bounds.Origin, box->Bounds.BoxExtent, debugcolor, 4);
}

void AOctreeCell::SetCellDimensions(const double _X, const double _Y, const double _Z)
{
	box->SetBoxExtent(FVector(_X,  _Y,  _Z));
}
void AOctreeCell::SetCellDimensions(const FVector _FVector)
{
	box->SetBoxExtent(_FVector);
}
void AOctreeCell::CustomDestroy()
{
	
	for (int i = 0; i < currentNumberOfChildren; i++)
	{
		AOctreeCell* _cell = cellChildren[i];
		if (!_cell) continue;
		_cell->CustomDestroy();
	}

	cellChildren.Empty();
	Destroy();
}

void AOctreeCell::SetOctree(AOctree* _this)
{
	octree = _this;
}

