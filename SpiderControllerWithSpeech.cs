using System.Collections;
using System.IO;
using HuggingFace.API; // Add this line to reference the HuggingFace API
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace HuggingFace.API.Examples {
  public class SpiderControllerWithSpeech : MonoBehaviour
  {
      [Header("Materials")]
      public Material InactiveMaterial;
      public Material GazedAtMaterial;
      public Material RedMaterial;

      [Header("References")]
      public Animator _animator;

      private AudioClip clip;
      private byte[] bytes;
      private bool recording;

      private AudioClip recordingClip;
      private bool isRecording;
      private byte[] audioBytes;

      private Renderer _myRenderer;

      private void Start() {
          _myRenderer = GetComponent<Renderer>();
      }

      private void Update() {
        if (Input.GetMouseButtonDown(0)) {
          StartRecording();
        }
        if (Input.GetMouseButtonDown(1)) {
          StopRecording();
        }
        if (recording && Microphone.GetPosition(null) >= clip.samples) {
          StopRecording();
        }
      }


      private void StartRecording() {
        Debug.Log("Recording...");
        clip = Microphone.Start(null, false, 10, 44100);
        recording = true;
      }

      private void StopRecording() {
        var position = Microphone.GetPosition(null);
        Microphone.End(null);
        var samples = new float[position * clip.channels];
        clip.GetData(samples, 0);
        bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
        recording = false;
        SendRecording();
      }

      private void SendRecording() {
        Debug.Log("Sending...");
        HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response => {
            if (response.Contains("Turn red."))
            {
                Debug.Log(response);
                _myRenderer.material = RedMaterial;
            } else if (response.Contains("Get to sleep.")){
              Debug.Log(response);
              _animator.SetTrigger("IsDead");
            } else if (response.Contains("Wake up.")){
              _animator.SetTrigger("IsDead");
            } else {
                Debug.Log(response);
            }
        }, error => {
            Debug.Log(error);
        });
      }

      private byte[] EncodeAsWAV(float[] samples, int frequency, int channels)
      {
          using (var memoryStream = new MemoryStream(44 + samples.Length * 2))
          {
              using (var writer = new BinaryWriter(memoryStream))
              {
                  writer.Write("RIFF".ToCharArray());
                  writer.Write(36 + samples.Length * 2);
                  writer.Write("WAVE".ToCharArray());
                  writer.Write("fmt ".ToCharArray());
                  writer.Write(16);
                  writer.Write((ushort)1);
                  writer.Write((ushort)channels);
                  writer.Write(frequency);
                  writer.Write(frequency * channels * 2);
                  writer.Write((ushort)(channels * 2));
                  writer.Write((ushort)16);
                  writer.Write("data".ToCharArray());
                  writer.Write(samples.Length * 2);

                  foreach (var sample in samples)
                  {
                      writer.Write((short)(sample * short.MaxValue));
                  }
              }

              return memoryStream.ToArray();
          }
      }
  }
}