using System;

namespace EFT.HideOut
{
	// Token: 0x02002108 RID: 8456
	public enum EHumanBones
	{
		// Token: 0x0400A5F8 RID: 42488
		None,
		// Token: 0x0400A5F9 RID: 42489
		IKController,
		// Token: 0x0400A5FA RID: 42490
		Mesh,
		// Token: 0x0400A5FB RID: 42491
		Vest_0,
		// Token: 0x0400A5FC RID: 42492
		Vest_1,
		// Token: 0x0400A5FD RID: 42493
		backpack,
		// Token: 0x0400A5FE RID: 42494
		backpack_0,
		// Token: 0x0400A5FF RID: 42495
		backpack_1,
		// Token: 0x0400A600 RID: 42496
		backpack_2,
		// Token: 0x0400A601 RID: 42497
		razgruz,
		// Token: 0x0400A602 RID: 42498
		razgruz_0,
		// Token: 0x0400A603 RID: 42499
		razgruz_1,
		// Token: 0x0400A604 RID: 42500
		razgruz_2,
		// Token: 0x0400A605 RID: 42501
		Root_Joint,
		// Token: 0x0400A606 RID: 42502
		HumanPelvis,
		// Token: 0x0400A607 RID: 42503
		HumanLThigh1,
		// Token: 0x0400A608 RID: 42504
		HumanLThigh2,
		// Token: 0x0400A609 RID: 42505
		HumanLCalf,
		// Token: 0x0400A60A RID: 42506
		HumanLFoot,
		// Token: 0x0400A60B RID: 42507
		HumanLToe,
		// Token: 0x0400A60C RID: 42508
		HumanRThigh1,
		// Token: 0x0400A60D RID: 42509
		HumanRThigh2,
		// Token: 0x0400A60E RID: 42510
		HumanRCalf,
		// Token: 0x0400A60F RID: 42511
		HumanRFoot,
		// Token: 0x0400A610 RID: 42512
		HumanRToe,
		// Token: 0x0400A611 RID: 42513
		Bear_Feet,
		// Token: 0x0400A612 RID: 42514
		USEC_Feet,
		// Token: 0x0400A613 RID: 42515
		BEAR_feet_1,
		// Token: 0x0400A614 RID: 42516
		weapon_holster_pistol,
		// Token: 0x0400A615 RID: 42517
		HumanSpine1,
		// Token: 0x0400A616 RID: 42518
		HumanGear1,
		// Token: 0x0400A617 RID: 42519
		HumanGear2,
		// Token: 0x0400A618 RID: 42520
		HumanGear3,
		// Token: 0x0400A619 RID: 42521
		HumanGear4,
		// Token: 0x0400A61A RID: 42522
		HumanGear4_1,
		// Token: 0x0400A61B RID: 42523
		HumanGear5,
		// Token: 0x0400A61C RID: 42524
		HumanSpine2,
		// Token: 0x0400A61D RID: 42525
		HumanSpine3,
		// Token: 0x0400A61E RID: 42526
		IK_S_LForearm1,
		// Token: 0x0400A61F RID: 42527
		IK_S_LForearm2,
		// Token: 0x0400A620 RID: 42528
		IK_S_LForearm3,
		// Token: 0x0400A621 RID: 42529
		IK_S_LPalm,
		// Token: 0x0400A622 RID: 42530
		IK_S_LDigit11,
		// Token: 0x0400A623 RID: 42531
		IK_S_LDigit12,
		// Token: 0x0400A624 RID: 42532
		IK_S_LDigit13,
		// Token: 0x0400A625 RID: 42533
		IK_S_LDigit21,
		// Token: 0x0400A626 RID: 42534
		IK_S_LDigit22,
		// Token: 0x0400A627 RID: 42535
		IK_S_LDigit23,
		// Token: 0x0400A628 RID: 42536
		IK_S_LDigit31,
		// Token: 0x0400A629 RID: 42537
		IK_S_LDigit32,
		// Token: 0x0400A62A RID: 42538
		IK_S_LDigit33,
		// Token: 0x0400A62B RID: 42539
		IK_S_LDigit41,
		// Token: 0x0400A62C RID: 42540
		IK_S_LDigit42,
		// Token: 0x0400A62D RID: 42541
		IK_S_LDigit43,
		// Token: 0x0400A62E RID: 42542
		IK_S_LDigit51,
		// Token: 0x0400A62F RID: 42543
		IK_S_LDigit52,
		// Token: 0x0400A630 RID: 42544
		IK_S_LDigit53,
		// Token: 0x0400A631 RID: 42545
		XYZ,
		// Token: 0x0400A632 RID: 42546
		LCollarbone_anim,
		// Token: 0x0400A633 RID: 42547
		RCollarbone_anim,
		// Token: 0x0400A634 RID: 42548
		RCollarbone_anim_XYZ,
		// Token: 0x0400A635 RID: 42549
		Weapon_root_3rd_anim,
		// Token: 0x0400A636 RID: 42550
		XYZ_1,
		// Token: 0x0400A637 RID: 42551
		Bend_Goal_Left,
		// Token: 0x0400A638 RID: 42552
		Bend_Goal_Right,
		// Token: 0x0400A639 RID: 42553
		Bend_Goal_Right_XYZ_1,
		// Token: 0x0400A63A RID: 42554
		HumanRibcage,
		// Token: 0x0400A63B RID: 42555
		IK_LForearm1,
		// Token: 0x0400A63C RID: 42556
		IK_LForearm2,
		// Token: 0x0400A63D RID: 42557
		IK_LForearm3,
		// Token: 0x0400A63E RID: 42558
		IK_LPalm,
		// Token: 0x0400A63F RID: 42559
		IK_LDigit11,
		// Token: 0x0400A640 RID: 42560
		IK_LDigit12,
		// Token: 0x0400A641 RID: 42561
		IK_LDigit13,
		// Token: 0x0400A642 RID: 42562
		IK_LDigit21,
		// Token: 0x0400A643 RID: 42563
		IK_LDigit22,
		// Token: 0x0400A644 RID: 42564
		IK_LDigit23,
		// Token: 0x0400A645 RID: 42565
		IK_LDigit31,
		// Token: 0x0400A646 RID: 42566
		IK_LDigit32,
		// Token: 0x0400A647 RID: 42567
		IK_LDigit33,
		// Token: 0x0400A648 RID: 42568
		IK_LDigit41,
		// Token: 0x0400A649 RID: 42569
		IK_LDigit42,
		// Token: 0x0400A64A RID: 42570
		IK_LDigit43,
		// Token: 0x0400A64B RID: 42571
		IK_LDigit51,
		// Token: 0x0400A64C RID: 42572
		IK_LDigit52,
		// Token: 0x0400A64D RID: 42573
		IK_LDigit53,
		// Token: 0x0400A64E RID: 42574
		Camera_animated,
		// Token: 0x0400A64F RID: 42575
		CameraContainer,
		// Token: 0x0400A650 RID: 42576
		Cam,
		// Token: 0x0400A651 RID: 42577
		HumanLCollarbone,
		// Token: 0x0400A652 RID: 42578
		HumanLUpperarm,
		// Token: 0x0400A653 RID: 42579
		HumanLForearm1,
		// Token: 0x0400A654 RID: 42580
		HumanLForearm2,
		// Token: 0x0400A655 RID: 42581
		HumanLForearm3,
		// Token: 0x0400A656 RID: 42582
		HumanLPalm,
		// Token: 0x0400A657 RID: 42583
		HumanLDigit11,
		// Token: 0x0400A658 RID: 42584
		HumanLDigit12,
		// Token: 0x0400A659 RID: 42585
		HumanLDigit13,
		// Token: 0x0400A65A RID: 42586
		HumanLDigit21,
		// Token: 0x0400A65B RID: 42587
		HumanLDigit22,
		// Token: 0x0400A65C RID: 42588
		HumanLDigit23,
		// Token: 0x0400A65D RID: 42589
		HumanLDigit31,
		// Token: 0x0400A65E RID: 42590
		HumanLDigit32,
		// Token: 0x0400A65F RID: 42591
		HumanLDigit33,
		// Token: 0x0400A660 RID: 42592
		HumanLDigit41,
		// Token: 0x0400A661 RID: 42593
		HumanLDigit42,
		// Token: 0x0400A662 RID: 42594
		HumanLDigit43,
		// Token: 0x0400A663 RID: 42595
		HumanLDigit51,
		// Token: 0x0400A664 RID: 42596
		HumanLDigit52,
		// Token: 0x0400A665 RID: 42597
		HumanLDigit53,
		// Token: 0x0400A666 RID: 42598
		HumanRCollarbone,
		// Token: 0x0400A667 RID: 42599
		HumanRUpperarm,
		// Token: 0x0400A668 RID: 42600
		HumanRForearm1,
		// Token: 0x0400A669 RID: 42601
		HumanRForearm2,
		// Token: 0x0400A66A RID: 42602
		HumanRForearm3,
		// Token: 0x0400A66B RID: 42603
		HumanRPalm,
		// Token: 0x0400A66C RID: 42604
		HumanRDigit11,
		// Token: 0x0400A66D RID: 42605
		HumanRDigit12,
		// Token: 0x0400A66E RID: 42606
		HumanRDigit13,
		// Token: 0x0400A66F RID: 42607
		HumanRDigit21,
		// Token: 0x0400A670 RID: 42608
		HumanRDigit22,
		// Token: 0x0400A671 RID: 42609
		HumanRDigit23,
		// Token: 0x0400A672 RID: 42610
		HumanRDigit31,
		// Token: 0x0400A673 RID: 42611
		HumanRDigit32,
		// Token: 0x0400A674 RID: 42612
		HumanRDigit33,
		// Token: 0x0400A675 RID: 42613
		HumanRDigit41,
		// Token: 0x0400A676 RID: 42614
		HumanRDigit42,
		// Token: 0x0400A677 RID: 42615
		HumanRDigit43,
		// Token: 0x0400A678 RID: 42616
		HumanRDigit51,
		// Token: 0x0400A679 RID: 42617
		HumanRDigit52,
		// Token: 0x0400A67A RID: 42618
		HumanRDigit53,
		// Token: 0x0400A67B RID: 42619
		Weapon_root,
		// Token: 0x0400A67C RID: 42620
		HumanNeck,
		// Token: 0x0400A67D RID: 42621
		HumanHead,
		// Token: 0x0400A67E RID: 42622
		HumanBackpack,
		// Token: 0x0400A67F RID: 42623
		weapon_holster,
		// Token: 0x0400A680 RID: 42624
		weapon_holster1,
		// Token: 0x0400A681 RID: 42625
		Camera_animated_3rd
	}
}
