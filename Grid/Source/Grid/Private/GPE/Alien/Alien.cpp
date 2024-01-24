
#include "\Unreal\Objectif3D_2ANNE\Grid\Source\Grid\Utils.h"
#include "GPE/Alien/Alien.h"


AAlien::AAlien()
{
 	PrimaryActorTick.bCanEverTick = true;
#if WITH_EDITOR 
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif
	Init();
}


bool AAlien::ShouldTickIfViewportsOnly() const
{
	return shouldTickIfViewportsOnly;
}

void AAlien::BeginPlay()
{
	Super::BeginPlay();
	Bind();
}
void AAlien::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	if (Destination())
			ClearTarget();

	if (Target)
		SetActorLocation(Target->GetActorLocation());
}
void AAlien::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

}

void AAlien::Init()
{
	skeletal = CREATE(USkeletalMeshComponent, "Skeletal")
	floatingPawn = CREATE(UFloatingPawnMovement, "FloatingPawn")
	sightComponent = CREATE(USightComponent,"SightComponent")
}

void AAlien::Bind()
{
	if (!sightComponent)
		return;
	sightComponent->OnTarget().AddDynamic(this, &AAlien::SeeTarget);
}

void AAlien::SeeTarget(AActor* _actor)
{
	
	Target = _actor;
}

void AAlien::ClearTarget()
{
	Target = nullptr;
	sightComponent->CleanTarget();
}

bool AAlien::Destination()
{
	if (Target)
		if (FVector::Distance(Target->GetActorLocation(), GetActorLocation()) >= 500.f)
				return true;
	return false;
}

