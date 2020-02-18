﻿using UnityEngine;
using DG.Tweening;


public class MainCarBehavior : VehicleBehavior {


    [SerializeField] private GameManager gameManager;


    protected override void UpdateInvincibilityDisplay() {

        goModel.GetComponent<Collider>().enabled = !lifeBehavior.isInvincible;

        ///TODO shader alpha
        var alpha = lifeBehavior.isInvincible ? 0.2f : 1;
        goModel.GetComponent<Renderer>().material.DOFade(alpha, 0.5f);
    }

    protected override void OnCollisionWithEnemy(VehicleBehavior vehicleBehavior) {
        base.OnCollisionWithEnemy(vehicleBehavior);

        ///TODO
    }

    protected override void OnCollisionWithObstacle(ObstacleBehavior obstacleBehavior) {
        base.OnCollisionWithObstacle(obstacleBehavior);

        ///TODO
    }

    protected override void OnCollisionWithCollectible(CollectibleBehavior collectibleBehavior) {
        base.OnCollisionWithCollectible(collectibleBehavior);

        collectibleBehavior.Collect();
    }

    protected override void OnVehicleExplode() {
        base.OnVehicleExplode();

        //trigger game over when main car has exploded
        gameManager.StopPlaying();
    }

}
