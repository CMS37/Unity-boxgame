# Hyper Casual Puzzle Game v1.0

## Overview
이 프로젝트는 Unity 엔진을 사용하여 제작된 2D 하이퍼 캐주얼 퍼즐 게임입니다. Kenney.nl의 에셋을 기반으로 BOXY BOY 스타일의 게임 플레이를 구현하였습니다. 

플레이어는 캐릭터를 조작해 박스를 밀고, 지정된 타겟 위에 올려놓는 방식으로 퍼즐을 해결하며 각 레벨을 클리어합니다.

## Features

### 플레이어 이동 및 애니메이션
- 4방향(위/아래/좌/우) 이동 가능
- 각 방향에 대해 애니메이션 적용

### 박스 밀기 & 퍼즐 해결
- 박스를 타겟 위치로 이동시켜 퍼즐 해결
- 퍼즐 해결 시 자동으로 다음 스테이지로 전환

### UI 시스템
- 각 레벨마다 홈/리셋 버튼 제공 (MainMenu 복귀 및 레벨 재시작 기능)
- UIController를 통해 박스 개수(전체 대비 타겟 위 박스 수)를 동적으로 카운트
- Canvas Scaler의 "Scale With Screen Size" 설정 적용 (기준 해상도 1920×1080)

### 메인 메뉴 & 이어하기 기능
- MainMenuController를 통한 새 게임, 이어하기(Continue), 종료 기능 제공
- PlayerPrefs에 저장된 "LastStage" 값을 통해 이어하기 구현

### 싱글톤 GameManager
- 싱글톤 패턴 및 DontDestroyOnLoad() 적용
- 게임 정보 중앙 관리 (LastStage 등)

## Project Structure
```
Assets/
├── Scripts/
│   ├── GameManager.cs
│   ├── PlayerMovement.cs
│   ├── BoxController.cs
│   ├── MainMenuController.cs
│   └── UIController.cs
├── Scenes/
│   ├── MainMenu.unity
│   ├── Level0.unity
│   └── Level1.unity ...
├── Animations/
├── Sprites/
ProjectSettings/
Packages/
```

## How to Play

### 메인 메뉴
- **New Game**: 새 게임 시작 (기존 진행 기록 초기화)
- **Continue**: 마지막 스테이지에서 이어서 시작
- **Quit**: 게임 종료

### 레벨 진행
- 박스를 캐릭터로 밀어 타겟 위치에 놓아 퍼즐 해결
- UI 상단에 "Boxes: X / Y"로 진행 상황 표시
- Home 버튼, Reset 버튼 제공

### 레벨 클리어 시
- 모든 박스가 타겟 위에 놓이면 자동 다음 레벨로 전환

## Development Notes & Future Enhancements

### Continue 기능 이슈
- 현재 이어하기 기능 이슈 발생중

### UI 개선
- 다양한 해상도 대응을 위한 Canvas 세부 설정 개선 - 완료

### 레벨 확장
- 추가 퍼즐 및 스테이지 기획 - 보류

### 성능 최적화
- 오브젝트 풀링 등 성능 개선 계획

---
**Version: v0.1**