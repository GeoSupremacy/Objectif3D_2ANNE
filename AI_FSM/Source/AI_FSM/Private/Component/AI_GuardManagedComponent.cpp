// Fill out your copyright notice in the Description page of Project Settings.


#include "Component/AI_GuardManagedComponent.h"
#include "GameMode/BaseGameMode.h"
#include "IA/IA_Guard.h"
#include "Manager/IA_GuardManager.h"

UAI_GuardManagedComponent::UAI_GuardManagedComponent()
{
	
	PrimaryComponentTick.bCanEverTick = true;

}


UIA_GuardManager* UAI_GuardManagedComponent::GetManager()
{
	ABaseGameMode* _gm = GetWorld()->GetAuthGameMode<ABaseGameMode>();
	if (!_gm)
	{
		GEngine->AddOnScreenDebugMessage(0, 10, FColor::Red, TEXT("UAI_GuardManagedComponent: Not ABaseGameMode "));
		return nullptr;
	}
	return _gm->GetGuardManager();
}

void UAI_GuardManagedComponent::Init()
{
	managed = Cast<AIA_Guard>(GetOwner());
	isManaged = GetManager()->AddGuard(this);
}

void UAI_GuardManagedComponent::Enable()
{
}

void UAI_GuardManagedComponent::Disable()
{
}

void UAI_GuardManagedComponent::RemoveGuard()
{
	if (!isManaged)
		return;
	isManaged = !GetManager()->RemoveGuard(this);
}
