// Fill out your copyright notice in the Description page of Project Settings.


#include "CameraManager.h"

bool UCameraManager::AddCamera(UCameraManagedComponent* _camera)
{
	if(cameras.Contains(_camera->ID()))
		return false;
	cameras.Add(_camera->ID(),_camera);
	return true;
}
