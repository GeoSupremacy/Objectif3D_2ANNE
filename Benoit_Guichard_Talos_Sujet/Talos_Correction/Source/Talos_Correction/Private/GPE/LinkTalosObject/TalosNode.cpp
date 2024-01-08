// Fill out your copyright notice in the Description page of Project Settings.


#include "GPE/LinkTalosObject/TalosNode.h"




void ATalosNode::AddLink(ATalosNode* _otherNode)
{

	FString _idConcat = FString::FromInt(id) + FString::FromInt(_otherNode->GetID());
	if (connectedNode.Contains(_idConcat))
	{
		return;
	}		
	
	UTalosLink* _link = NewObject<UTalosLink>(this);
	_link->Connect(this, _otherNode);
	connectedNode.Add(_idConcat, _link);
}

void ATalosNode::NodeBehaviour()
{
	for (TPair<FString, UTalosLink*> _link : connectedNode)
	{
	
		if (!_link.Value)
			continue;
		_link.Value->Debug();
		_link.Value->IsValidLink(validLayer);
		_link.Value->Run();
	}

	
}


ATalosNode::ATalosNode()
{
	PrimaryActorTick.bCanEverTick = true;
}



void ATalosNode::BeginPlay()
{
	Super::BeginPlay();
	id = FMath::Rand();
}
void ATalosNode::Tick(float _detaTime)
{
	Super::Tick(_detaTime);
	NodeBehaviour();
}

