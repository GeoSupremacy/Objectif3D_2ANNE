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
    UE_LOG(LogTemp, Error, TEXT("Count: %d"), data->GetFVectorNodes().Num());
    for (int i = 0; i < data->GetFVectorNodes().Num(); i++)
    {
        /*
        bool _canRight = i % size != size - 1,
            _canTop = i > size,
            _canDown = i < (size * size) - size,
            _canLeft = i % size != 0;
        if (_canRight)
            data->GetFVectorNodes()[i]->AddSuccessor(i + 1);
        if (_canLeft)
            data->GetFVectorNodes()[i]->AddSuccessor(i - 1);
        if (_canTop)
        {
            data->GetFVectorNodes()[i]->AddSuccessor(i - size);
            if (_canRight)
                data->GetFVectorNodes()[i]->AddSuccessor((i + 1 - size));
            if (_canLeft)
                data->GetFVectorNodes()[i]->AddSuccessor((i - 1 - size));
        }
        if (_canDown)
        {
            data->GetFVectorNodes()[i]->AddSuccessor(i + size);
            if (_canRight)
                data->GetFVectorNodes()[i]->AddSuccessor((i + 1 + size));
            if (_canLeft)
                data->GetFVectorNodes()[i]->AddSuccessor((i - 1 + size));
        }
       */ 
    }
    
}

void AGridNav::DrawDebug()
{
    for (int x = 0; x < size; x++)
    {
        for (int y = 0; y < size; y++)
        {
            DrawDebugBox(GetWorld(),FVector(x * gap, y * gap, 0) + GetActorLocation(), FVector::One() * 100.f, FColor::White);
      
        }
    }
    if (!data)
        return;
    for (int i = 0; i < data->GetFVectorNodes().Num(); i++)
    {
       // data->GetFVectorNodes()[i]->DrawGizmos(gridNodeColor, gridLinesColor);
    }
}

void AGridNav::Generate()
{
    if (!data)
        return;
    data->GetFVectorNodes().Empty();
    for (int x = 0; x < size; x++)
    {
        for (int y = 0; y < size; y++)
        {
            FVector _pos = FVector(x * gap, y * gap, 0) + GetActorLocation();
            FRotator Rotation(0.0f, 0.0f, 0.0f);
            FActorSpawnParameters SpawnInfo;
            currentNode = GetWorld()->SpawnActor<ANodeGrid>(_pos, Rotation, SpawnInfo);
            
            currentNode->SetActorLocation(_pos);
               //_node->SetGrid(data),
            //data->SetNodes(1);
          
            data->AddVector(currentNode->GetActorLocation());
        }
    }
    SetSuccessors();
}

