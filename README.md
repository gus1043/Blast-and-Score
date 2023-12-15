# Blast-and-Score
게임프로그래밍 2023-2 기말 프로젝트
 
**1.	게임 설명**
   
-수류탄과 연습 더미가 생겨나고 수류탄을 던져 연습 더미를 맞추는 게임이다. 

수류탄이 생성될 때 노란색 이펙트가 생기고 수류탄이 굴러서 더미와 충돌하는 것을 방지해 Rigidbody-Freeze rotation을 해주었다.

또한, 두 생성 범위를 분리해야 자동으로 처리 되는 더미가 생기는 것을 방지하였다.
<img width="631" alt="스크린샷 2023-12-15 163919" src="https://github.com/gus1043/Blast-and-Score/assets/80878955/302d310f-f11e-4407-935f-0c7a666614b7">

 -수류탄을 grab하면 “fire in the hole”이라는 소리가 난다. 
 
 연습더미가 수류탄에 맞으면 주황색 이펙트와 터지는 소리가 나며 더미와 수류탄이 사라진다. (시뮬레이터 상 캡쳐를 하지 못했습니다.)
 
-Ui panel에는 총 60초 동안 남은 시간과 처치한 연습 더미 수가 기록된다.
<img width="691" alt="스크린샷 2023-12-15 163800" src="https://github.com/gus1043/Blast-and-Score/assets/80878955/c5362612-91de-405b-81f7-4035dfe71ece">

-시간이 지날수록 더미의 크기가 점점 작아져 맞추기 힘들어지는 레벨 디자인을 하였다.
<img width="691" alt="스크린샷 2023-12-15 163729" src="https://github.com/gus1043/Blast-and-Score/assets/80878955/dde20d38-63db-4967-ba9b-2c187e729098">
