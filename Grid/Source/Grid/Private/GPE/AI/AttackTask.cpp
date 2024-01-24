#include "GPE/Alien/Enemy.h"
#include "GPE/Component/AttackSystemComponent.h"
#include "GPE/AI/AttackTask.h"

EBTNodeResult::Type UAttackTask::ExecuteTask(UBehaviorTreeComponent& OwnerCop, uint8* NodeMemery)
{
	Super::ExecuteTask(OwnerCop, NodeMemery);
	AEnemy* _enemy = Cast<AEnemy>(brain->GetControlledPawn());
	if (!_enemy)
		return EBTNodeResult::Failed;
	_enemy->GetAttack()->Attack();
	return EBTNodeResult::Type();
}
