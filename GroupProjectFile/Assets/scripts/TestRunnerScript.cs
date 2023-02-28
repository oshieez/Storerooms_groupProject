using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestRunnerScript
{
    [Test]
    public void PlayerSurvivesForOneMinute()
    {
        // Load the game scene
        SceneManager.LoadScene("Game");

        // Find the player object
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Find the enemy object
        GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");

        // Set the player's initial position and rotation
        playerObject.transform.position = new Vector3(0, 0, 0);
        playerObject.transform.rotation = Quaternion.identity;

        // Set the enemy's initial position and rotation
        enemyObject.transform.position = new Vector3(5, 0, 0);
        enemyObject.transform.rotation = Quaternion.identity;

        // Get the player's health script
        PlayerHealth playerHealth = playerObject.GetComponent<PlayerHealth>();

        // Get the enemy's movement script
        EnemyMovement enemyMovement = enemyObject.GetComponent<EnemyMovement>();

        // Set the enemy to chase the player
        enemyMovement.target = playerObject.transform;

        // Run the game for one minute
        float time = 0;
        while (time < 60)
        {
            time += Time.deltaTime;
            playerHealth.TakeDamage(0); // This will simulate the player's health decreasing over time
        }

        // Check that the player has won the game
        Assert.AreEqual("Win", SceneManager.GetActiveScene().name);
    }

    [Test]
    public void PlayerLosesIfEnemyTouches()
    {
        // Load the game scene
        SceneManager.LoadScene("Game");

        // Find the player object
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Find the enemy object
        GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");

        // Set the player's initial position and rotation
        playerObject.transform.position = new Vector3(0, 0, 0);
        playerObject.transform.rotation = Quaternion.identity;

        // Set the enemy's initial position and rotation
        enemyObject.transform.position = new Vector3(2, 0, 0);
        enemyObject.transform.rotation = Quaternion.identity;

        // Get the player's health script
        PlayerHealth playerHealth = playerObject.GetComponent<PlayerHealth>();

        // Get the enemy's movement script
        EnemyMovement enemyMovement = enemyObject.GetComponent<EnemyMovement>();

        // Set the enemy to chase the player
        enemyMovement.target = playerObject.transform;

        // Run the game for a few seconds
        float time = 0;
        while (time < 3)
        {
            time += Time.deltaTime;
            playerHealth.TakeDamage(0); // This will simulate the player's health decreasing over time

            // Check if the player has touched the enemy
            if (Vector3.Distance(playerObject.transform.position, enemyObject.transform.position) < 0.5f)
            {
                // Check that the player has lost the game
                Assert.AreEqual("Lose", SceneManager.GetActiveScene().name);
                return;
            }
        }

        // Check that the player has not lost the game
        Assert.AreNotEqual("Lose", SceneManager.GetActiveScene().name);
    }
}

