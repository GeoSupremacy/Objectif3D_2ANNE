#include "GPE/AI/Custom_AIController.h"
#include "\Unreal\Objectif3D_2ANNE\Grid\Source\Grid\Utils.h"
#include "GPE/AI/TaskNode.h"

EBTNodeResult::Type UTaskNode::ExecuteTask(UBehaviorTreeComponent& OwnerCop, uint8* NodeMemery)
{
	Super::ExecuteTask(OwnerCop ,NodeMemery);

	tree = &OwnerCop;
	brain = Cast <ACustom_AIController> (OwnerCop.GetOwner());
	if(!brain)
		return EBTNodeResult::Failed;
	SCREEN_DEBUG_MESSAGE_WARNING(3, "brain")
	return EBTNodeResult::Type();
}
