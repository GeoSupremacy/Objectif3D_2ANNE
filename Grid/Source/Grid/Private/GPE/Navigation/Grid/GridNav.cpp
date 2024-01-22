// Fill out your copyright notice in the Description page of Project Settings.


#include "GPE/Navigation/Grid/GridNav.h"


AGridNav::AGridNav()
{
 	
	PrimaryActorTick.bCanEverTick = true;

}


void AGridNav::BeginPlay()
{
	Super::BeginPlay();
    Generate();
}
void AGridNav::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
    DrawDebug();
}

void AGridNav::SetSuccessors()
{
    for (int i = 0; i < size * size; i++)
    {
        bool _canRight = i % size != size - 1,
            _canTop = i >= size,
            _canDown = i < (size * size) - size,
            _canLeft = i % size != 0;
        if (_canRight)
            data->GetNodes()[i]->AddSuccessor(i + 1);
        if (_canLeft)
            data->GetNodes()[i]->AddSuccessor(i - 1);
        if (_canTop)
        {
            data->GetNodes()[i]->AddSuccessor(i - size);
            if (_canRight)
                data->GetNodes()[i]->AddSuccessor((i + 1 - size));
            if (_canLeft)
                data->GetNodes()[i]->AddSuccessor((i - 1 - size));
        }
        if (_canDown)
        {
            data->GetNodes()[i]->AddSuccessor(i + size);
            if (_canRight)
                data->GetNodes()[i]->AddSuccessor((i + 1 + size));
            if (_canLeft)
                data->GetNodes()[i]->AddSuccessor((i - 1 + size));
        }
    }
}

void AGridNav::DrawDebug()
{
    for (int x = 0; x < size; x++)
    {
        for (int y = 0; y < size; y++)
        {
            DrawDebugBox(GetWorld(),FVector(x * gap, 0, y * gap) + GetActorLocation(), FVector::One() * .2f, FColor::White);
      
        }
    }
    if (!data)
        return;
    for (int i = 0; i < data->GetNodes().Num(); i++)
    {
        data->GetNodes()[i]->DrawGizmos(gridNodeColor, gridLinesColor);
    }
}

void AGridNav::Generate()
{
    if (!data)
        return;
    data->GetNodes().Empty();
    for (int x = 0; x < size; x++)
    {
        for (int y = 0; y < size; y++)
        {
            FVector _pos = FVector(x * gap, 0, y * gap) + GetActorLocation();
            ANodeGrid* _node = GetWorld()->SpawnActor<ANodeGrid>();
            
                _node->SetGrid(data),
                _node->SetActorLocation(_pos);
          
            data->GetNodes().Add(_node);
        }
    }
    SetSuccessors();
}

