// Fill out your copyright notice in the Description page of Project Settings.

#include "GPE/LinkTalosObject/TalosNode.h"
#include "Kismet/KismetSystemLibrary.h"
#include "GPE/LinkTalosObject/TalosLink.h"


void UTalosLink::Run()
{
	if (!to || !from)
		return;
	if (isValid)
	{
		if (!isLinkedToSource)
		{
			if (to->IsSource())
			{
				from->SetSource(true);
				isLinkedToSource = true;
			}
			else if (!from->IsSource())
			{
				to->SetSource(false);
				isLinkedToSource = false;
			}
			else
			{
				to->SetSource(true);
				isLinkedToSource = true;
			}
		}
		else
		{
			if (!from->IsSource())
			{
				to->SetSource(false);
				isLinkedToSource = false;
			}
			else
			{
				to->SetSource(true);
				isLinkedToSource = true;
			}
		}
	}
	else
	{
		if (isLinkedToSource)
		{
			from->SetSource(false);
			isLinkedToSource = false;
		}
		else
		{
			to->SetSource(false);
		}
	}
}
void UTalosLink::Connect(TObjectPtr<ATalosNode> _from, TObjectPtr<ATalosNode> _to)
{
	from = _from;
	to = _to;
}
void UTalosLink::Debug()
{

	if (!from || !to)
		return;

	DrawDebugLine(GetWorld(), from->GetActorLocation(), to->GetActorLocation(), isValid? FColor::Red: FColor::White, false,-1,0,5);
}
bool UTalosLink::IsValidLink(TArray<TEnumAsByte<EObjectTypeQuery>> _validLayer)
{
	FHitResult _result;
	TArray<AActor*> _ignore = { from };
	const bool _hit = UKismetSystemLibrary::LineTraceSingleForObjects(GetWorld(), from ->GetActorLocation(), to->GetActorLocation(), _validLayer, true,
		_ignore, EDrawDebugTrace::ForOneFrame, _result, true);
	return isValid =(_hit && Cast<ATalosNode>(_result.GetActor()));
}
