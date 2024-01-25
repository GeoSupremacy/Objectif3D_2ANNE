#include "GPE/Alien/Enemy.h"
#include "GPE/Component/AttackSystemComponent.h"

#include "\Unreal\Objectif3D_2ANNE\Grid\Source\Grid\Utils.h"
#include "GPE/AI/AttackTask.h"

EBTNodeResult::Type UAttackTask::ExecuteTask(UBehaviorTreeComponent& OwnerCop, uint8* NodeMemery)
{
	Super::ExecuteTask(OwnerCop, NodeMemery);

		
	AEnemy* _enemy = Cast<AEnemy>(brain->GetControlledPawn());
	if (!_enemy)
		return EBTNodeResult::Failed;
	SCREEN_DEBUG_MESSAGE_WARNING(3, "attq")
	_enemy->GetAttack()->Attack();
	return EBTNodeResult::Succeeded;
}
