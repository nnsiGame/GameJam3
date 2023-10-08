using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BGM_effct : MonoBehaviour
{
    public GameObject[] effects; // �G�t�F�N�g��Prefab���i�[����z��
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

        // ���ɃG�t�F�N�g������΍폜
        if (currentEffect != null)
        {
            Destroy(currentEffect);
        }

        // �����_���ȃC���f�b�N�X�𐶐�
        int randomIndex = Random.Range(0, effects.Length);

        // �J�����͈̔͂��擾
        Camera mainCamera = Camera.main;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // �O�񐶐��������W�ƈقȂ郉���_���Ȉʒu�ɃG�t�F�N�g�𐶐�
        Vector2 randomPosition;
        do
        {
            float randomX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
            float randomY = Random.Range(-cameraHeight / 2f, cameraHeight / 2f);
            randomPosition = new Vector2(randomX, randomY);
        } while (randomPosition == lastGeneratedPosition);

        lastGeneratedPosition = randomPosition;

        // �V�����G�t�F�N�g�𐶐�
        currentEffect = Instantiate(effects[randomIndex], randomPosition, Quaternion.identity);
    }
}
