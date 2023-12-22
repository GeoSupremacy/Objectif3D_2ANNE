#include "GUI/BaseHUD.h"

void ABaseHUD::BeginPlay()
{
	Super::BeginPlay();
	player = Cast<APlayableCharacter>(FPC->GetPawn());
	InitUI();
}

void ABaseHUD::InitUI()
{
}
