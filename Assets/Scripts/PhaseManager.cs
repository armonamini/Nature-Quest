using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PhaseManager : MonoBehaviour
{
    [System.Serializable]
    public class PhaseGroup
    {
        public GameObject groupObject;
        public Image imageButton;
        public Outline outline;
        public bool isSelected;
        public string phaseName;
        public string phaseDescription;
        public RawImage phaseImageDisplay;
        public Sprite phaseSprite;
    }

    [SerializeField] private List<PhaseGroup> phaseGroups = new List<PhaseGroup>();
    [SerializeField] private Button submitButton;
    [SerializeField] private TextMeshProUGUI resultsText;
    [SerializeField] private GameObject resultsPage;
    [SerializeField] private PhaseModalManager modalManager;
    private List<PhaseGroup> selectedPhases = new List<PhaseGroup>();

    private void Start()
    {
        // Initialize all phase groups
        foreach (var phase in phaseGroups)
        {
            if (phase.imageButton != null)
            {
                // Add button component if not present
                Button button = phase.imageButton.GetComponent<Button>();
                if (button == null)
                {
                    button = phase.imageButton.gameObject.AddComponent<Button>();
                }

                // Add outline component if not present
                if (phase.outline == null)
                {
                    phase.outline = phase.imageButton.gameObject.AddComponent<Outline>();
                    phase.outline.effectColor = new Color(1f, 0.92f, 0.016f, 1f);
                    phase.outline.effectDistance = new Vector2(4, 4);
                    phase.outline.enabled = false;
                }

                // Add click listener
                button.onClick.AddListener(() => OnPhaseSelected(phase));
            }
        }

        // Add submit button listener
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(OnSubmitClicked);
        }
    }

    private void OnPhaseSelected(PhaseGroup selectedPhase)
    {
        // Show the modal with phase information
        if (modalManager != null)
        {
            modalManager.ShowPhaseModal(selectedPhase.phaseName, selectedPhase.phaseDescription, selectedPhase.phaseImageDisplay, selectedPhase.phaseSprite);
        }

        // Toggle selection
        selectedPhase.isSelected = !selectedPhase.isSelected;
        selectedPhase.outline.enabled = selectedPhase.isSelected;

        // Update selected phases list
        if (selectedPhase.isSelected)
        {
            if (!selectedPhases.Contains(selectedPhase))
            {
                selectedPhases.Add(selectedPhase);
            }
        }
        else
        {
            selectedPhases.Remove(selectedPhase);
        }
    }

    private void OnSubmitClicked()
    {
        if (selectedPhases.Count > 0)
        {
            // Update the results text to show all selected phases
            if (resultsText != null)
            {
                string phasesList = string.Join(", ", selectedPhases.ConvertAll(p => p.phaseName));
                resultsText.text = $"You have matched: {phasesList}";
            }

            // Show the results page
            if (resultsPage != null)
            {
                resultsPage.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Please select at least one phase before submitting");
        }
    }

    // Public method to get all selected phases
    public List<PhaseGroup> GetSelectedPhases()
    {
        return selectedPhases;
    }

    // Public method to clear all selections
    public void ClearSelection()
    {
        foreach (var phase in selectedPhases)
        {
            phase.isSelected = false;
            phase.outline.enabled = false;
        }
        selectedPhases.Clear();
    }
} 