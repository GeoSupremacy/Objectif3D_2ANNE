#include "Component/AI_GuardManagedComponent.h"
#include "Manager/IA_GuardManager.h"

TArray<UAI_GuardManagedComponent*> UIA_GuardManager::GetGuardInScene() const
{
	TArray<UAI_GuardManagedComponent*> _array;
	for(auto _guard : guards)
		_array.Add(_guard.Value);
	
	return _array;
}

bool UIA_GuardManager::AddGuard(UAI_GuardManagedComponent* _guard)
{
	if (guards.Contains(_guard->ID().ToLower()))
		return false;
	
	guards.Add(_guard->ID().ToLower(), _guard);
	return true;
}
bool UIA_GuardManager::RemoveGuard(UAI_GuardManagedComponent* _guard)
{
	if (!guards.Contains(_guard->ID().ToLower()))
		return false;
	guards.Remove(_guard->ID().ToLower());
	return true;
}
void UIA_GuardManager::DisableGuard(FString _id)
{
	if (!guards.Contains(_id))
		return;

	guards[_id.ToLower()]->Disable();
}
void UIA_GuardManager::EnableGuard(FString _id)
{
	if (!guards.Contains(_id))
		return;

	guards[_id.ToLower()]->Enable();
}
