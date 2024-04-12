using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayer;
    Camera mainCamera;

    public static event Action<EnemyBrain> OnEnemySelected;
    public static event Action OnNoSelection;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        SelectEnemy();
    }

    public void SelectEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition),
                                                 Vector2.zero, Mathf.Infinity, enemyLayer);


            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out EnemyBrain enemy))
                {
                    OnEnemySelected?.Invoke(enemy);

                }
                else
                {
                    OnNoSelection?.Invoke();
                }
            }
        }

    }
}