using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BGM_effct : MonoBehaviour
{
    public GameObject[] effects; // エフェクトのPrefabを格納する配列
    private GameObject currentEffect;
    private Vector2 lastGeneratedPosition;

    void Start()
    {
       // GenerateRandomEffect();
    }

    private void Update()
    {
        if (Music.IsJustChangedBar())
        {
            DOTween
                .To(value => OnScale(value), 0, 1, 0.1f)

            ;
            
        }
        else if (Music.IsJustChangedBeat())
        {
            GenerateRandomEffect();
        }
        }
    private void OnScale(float value)
    {
        var scale = Mathf.Lerp(1, 1.2f, value);
        //transform.localScale = new Vector3(scale, scale, scale);
    }
    void GenerateRandomEffect()
    {

        // 既にエフェクトがあれば削除
        if (currentEffect != null)
        {
            Destroy(currentEffect);
        }

        // ランダムなインデックスを生成
        int randomIndex = Random.Range(0, effects.Length);

        // カメラの範囲を取得
        Camera mainCamera = Camera.main;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // 前回生成した座標と異なるランダムな位置にエフェクトを生成
        Vector2 randomPosition;
        do
        {
            float randomX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
            float randomY = Random.Range(-cameraHeight / 2f, cameraHeight / 2f);
            randomPosition = new Vector2(randomX, randomY);
        } while (randomPosition == lastGeneratedPosition);

        lastGeneratedPosition = randomPosition;

        // 新しいエフェクトを生成
        currentEffect = Instantiate(effects[randomIndex], randomPosition, Quaternion.identity);
    }
}
