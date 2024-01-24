#include "BehaviorTree/BlackboardComponent.h"
#include "\Unreal\Objectif3D_2ANNE\Grid\Source\Grid\Utils.h"
#include "GPE/Component/DetectorSystemComponent.h"
#include "GPE/Component/AttackSystemComponent.h"
#include "GPE/Alien/Enemy.h"


AEnemy::AEnemy()
{
 	// Set this pawn to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	RootComponent = CREATE(USceneComponent, "Root");
	skeleton = CREATE(USkeletalMeshComponent, "Skeletal")
	skeleton->SetupAttachment(RootComponent);
	aiController = CREATE(ACustom_AIController, "AI")
	detection = CREATE(UDetectorSystemComponent, "SightComponent")
	AddOwnedComponent(detection);
	attack = CREATE(UAttackSystemComponent, "Attack")
}


void AEnemy::BeginPlay()
{
	Super::BeginPlay();
	Init();
}
void AEnemy::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}
void AEnemy::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

}

void AEnemy::Init()
{
	if (!detection)
		return;

	aiController = Cast<ACustom_AIController>(GetController());
	if (!aiController)
		return;
	detection.Get()->OnTargetFond().AddDynamic(aiController, &ACustom_AIController::ReceiveTarget);
	detection.Get()->OnTargetDetected().AddDynamic(aiController, &ACustom_AIController::ReceiveTargetDetected);

	if (!attack)return;
	attack.Get()->OnRangeUpdate().AddDynamic(aiController, &ACustom_AIController::ReceiveIsInRange);
	detection.Get()->OnTargetFond().AddDynamic(attack, &UAttackSystemComponent::SetTarget);
}

