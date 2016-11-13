using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmancipationEditor : Editor {

	private string[] pagesList = {"story.txt", "story2.txt", "story3.txt", "story4.txt", "story5.txt", "story6.txt", "story7.txt", "story8.txt"};
	private int currentPage = -1;
	private bool completed;

	public void Update() {
		if (!completed && isPageComplete() && currentPage != -1 && getCrazyComponent().isStarted()) {
			getInputText ().showFileComplete ();
			completed = true;
		}
	}
	
	public void launchCreepyTextEvent() {
		getCrazyComponent().start ();
	}

	public void stopCreepyTextEvent() {
		getCrazyComponent().stop ();
	}

	public void loadNewPage() {
		setNextPage ();
		getOutputText ().setTextFromFile (pagesList[currentPage]);
		completed = false;
	}
		
	public bool isPageComplete() {
		return getOutputText ().isAllTextWritten ();
	}

	private CrazyText getCrazyComponent() {
		return getOutputText().GetComponent<CrazyText> ();
	}

	private void setNextPage() {
		if (currentPage < pagesList.Length - 1) {
			++currentPage;
		} else if (currentPage == pagesList.Length - 1) {
			currentPage = 0;
		}
	}
}
