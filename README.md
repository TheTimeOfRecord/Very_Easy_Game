# Very_Easy_Game
 정말 쉬울까?
## 목표 (Goal)
점프와 달리기와 여러 아이템을 이용해 목적지까지 도달하는 3D 플랫포머 게임
## 구현내용 (Implemented Features)
- 플레이어 움직임 (Move, Jump, Look)
- 플레이어 Status UI (체력, 스테미나)

## 구현해야 할 내용 (Features To Be Implemented)
- 아이템
 - 아이템 데이터 (ScriptableObject)
 - 아이템 상호작용 (동적 환경 조사)
 - 아이템 사용 (Coroutine)
- 상호작용 지형
  - 점프대 생성
- 플랫폼
  - 플랫폼 지형 생성

## 트러블 슈팅 (Trouble Shooting)
1. Look 기능에서 Mouse의 방향을 `Delta`값으로 조절하는지 `Vector2`값으로 조절하는지 정확히 파악하기
```cs
private void CameraLook()
{
    camCurXRot = mouseDelta.y * lookSensitivity; // <-
    camCurXRot = Mathf.Clamp(camCurXRot, minXRotLook, maxXRotLook);
    cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

    transform.eulerAngles = new Vector3(0, mouseDelta.x * lookSensitivity, 0); // <-
}
```
이 코드에서 <- 화살표로 표시한 줄의 등호를 +=으로 바꿔야 한다.
마우스 위치가 아닌 마우스 `Delta`값(마우스 변화량)을 받아서 변경해주는 것이므로, +=으로 설정해주지 않으면 Look이 제대로 작동하지 않는다.

2. `Input Action`의 `Control Type` 변경 후, `Binding` 설정까지 바꾸기
```cs
private void CameraLook()
{
    camCurXRot += mouseDelta.y * lookSensitivity;
    camCurXRot = Mathf.Clamp(camCurXRot, minXRotLook, maxXRotLook);
    cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

    transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
}
```
다음과 같이 코드를 문제 없이 고쳤는데, `Game`화면에서 화면이 Y축으로 빙글빙글 도는 현상이 발생했다.
Y축에서 문제가 있으므로 Y축의 값을 담당하는 `mouseDelta.x * lookSensitivity` 부분의 값을 고려하여 문제점을 찾았다.
여기서 mouseDelta값을 받아오는 `Input Action`에서 `Control Type`은 `Delta`값으로 되어있지만, `Binding`은 `Mouse Pos(Vector2)`값으로 되어있는 것을 확인 후 `Binding`을 `Delta`값으로 바꿔주었다.
