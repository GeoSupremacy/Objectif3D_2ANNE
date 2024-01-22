

#include "GPE/AI/TaskNode.h"

EBTNodeResult::Type UTaskNode::ExecuteTask(UBehaviorTreeComponent& OwnerCop, uint8* NodeMemery)
{
	Super::ExecuteTask(OwnerCop ,NodeMemery);

	tree = &OwnerCop;
	brain = Cast <ACustom_AIController> (OwnerCop.GetOwner());
	return EBTNodeResult::InProgress;
}
