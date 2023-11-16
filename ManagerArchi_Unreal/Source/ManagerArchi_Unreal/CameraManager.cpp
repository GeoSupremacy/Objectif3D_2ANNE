// Fill out your copyright notice in the Description page of Project Settings.


#include "CameraManager.h"

bool UCameraManager::AddCamera(UCameraManagedComponent* _camera)
{
	if(cameras.Contains(_camera->ID().ToLower()))
		return false;
	cameras.Add(_camera->ID().ToLower(),_camera);
	return true;
}

bool UCameraManager::RemoveCamera(UCameraManagedComponent* _camera)
{
	if (!cameras.Contains(_camera->ID().ToLower()))
		return false;
	cameras.Remove(_camera->ID().ToLower());
		return true;
}

void UCameraManager::DisableCamera(FString _id)
{
	if (!cameras.Contains(_id))
		return;

	cameras[_id.ToLower()]->Disable();
}

void UCameraManager::EnableCamera(FString _id)
{
	if (!cameras.Contains(_id))
		return;

	cameras[_id.ToLower()]->Enable();
}
